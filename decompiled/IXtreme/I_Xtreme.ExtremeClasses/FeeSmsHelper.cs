using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace I_Xtreme.ExtremeClasses;

internal static class FeeSmsHelper
{
    internal static bool TrySend(string connectionString, string phone, string message, out string errorMessage)
    {
        // Load credentials
        string username = null, password = null, sender = null, url = null;
        try
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            using var cmd = new SqlCommand("SELECT TOP 1 url, username, password, sender FROM tbl_SMSAccount", conn);
            using var rdr = cmd.ExecuteReader();
            if (!rdr.Read())
            {
                errorMessage = "SMS account is not configured. Set it up under Settings.";
                return false;
            }
            url      = rdr["url"]     .ToString().Trim();
            username = rdr["username"].ToString().Trim();
            password = rdr["password"].ToString().Trim();
            sender   = rdr["sender"]  .ToString().Trim();
        }
        catch (Exception ex)
        {
            errorMessage = $"Could not load SMS account: {ex.Message}";
            return false;
        }

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            errorMessage = "SMS account is not configured. Set it up under Settings.";
            return false;
        }

        string baseUrl = string.IsNullOrEmpty(url) || !url.StartsWith("http")
            ? "https://www.egosms.co/api/v1/plain/?"
            : (url.EndsWith("?") ? url : url + "?");

        // Normalize the recipient to a Ugandan MSISDN; skip invalid numbers before hitting the gateway.
        string normalized = SmsReminderLogic.NormalizePhone(phone);
        if (normalized == null)
        {
            errorMessage = $"Invalid phone number: {phone}";
            return false;
        }

        // URL-encode every value so '&', '#', '=', '+' in names/school/message can't corrupt the query.
        string requestUri = $"{baseUrl}number={Uri.EscapeDataString(normalized)}" +
                            $"&message={Uri.EscapeDataString(message ?? string.Empty)}" +
                            $"&username={Uri.EscapeDataString(username)}" +
                            $"&password={Uri.EscapeDataString(password)}" +
                            $"&sender={Uri.EscapeDataString(sender ?? string.Empty)}";

        string response = null;
        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol  = SecurityProtocolType.Tls12;
            var req = (HttpWebRequest)WebRequest.Create(requestUri);
            req.Method      = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            using var resp   = (HttpWebResponse)req.GetResponse();
            using var reader = new StreamReader(resp.GetResponseStream());
            response = reader.ReadToEnd().Trim();
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            return false;
        }
        finally
        {
            SaveLog(connectionString, phone, response ?? "", message);
        }

        // egosms returns a positive integer on success (message count / batch ID)
        if (int.TryParse(response, out int code) && code > 0)
        {
            errorMessage = null;
            return true;
        }

        errorMessage = string.IsNullOrEmpty(response) ? "No response from SMS gateway." : $"SMS gateway error: {response}";
        return false;
    }

    private static void SaveLog(string connectionString, string phone, string response, string message)
    {
        try
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            using var cmd = new SqlCommand(
                "INSERT INTO tbl_SMSLog (date, recipients, response, message) VALUES (@d, @r, @resp, @m)", conn);
            cmd.Parameters.Add("@d",    SqlDbType.DateTime).Value          = DateTime.Now;
            cmd.Parameters.Add("@r",    SqlDbType.VarChar,  5000).Value    = phone;
            cmd.Parameters.Add("@resp", SqlDbType.VarChar,  100).Value     = response?.Length > 100 ? response.Substring(0, 100) : response ?? "";
            cmd.Parameters.Add("@m",    SqlDbType.NVarChar, 500).Value     = message;
            cmd.ExecuteNonQuery();
        }
        catch { /* log failure is non-fatal */ }
    }
}
