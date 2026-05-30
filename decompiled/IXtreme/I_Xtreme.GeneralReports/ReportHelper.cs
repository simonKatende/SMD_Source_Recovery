using System;
using System.Data.SqlClient;
using System.Drawing;
using AlienAge.Connectivity;
using AlienAge.Security;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace I_Xtreme.GeneralReports;

internal static class ReportHelper
{
    internal static (string name, string contact) GetSchoolInfo()
    {
        const string sql = "SELECT TOP 1 SchoolName, fullContact FROM SchoolDetails";
        try
        {
            using var conn = new SqlConnection(DataConnection.ConnectToDatabase());
            using var cmd  = new SqlCommand(sql, conn);
            conn.Open();
            using var rdr = cmd.ExecuteReader();
            if (!rdr.Read()) return ("", "");
            string rawName    = rdr.IsDBNull(0) ? "" : rdr.GetString(0);
            string rawContact = rdr.IsDBNull(1) ? "" : rdr.GetString(1);
            string name;
            try { name = CryptorEngine.Decrypt(rawName); }
            catch { name = rawName; }
            return (name, rawContact);
        }
        catch { return ("", ""); }
    }

    internal static void AddSchoolHeader(XtraReport report, string reportTitle)
    {
        var (schoolName, contact) = GetSchoolInfo();
        float pageWidth = report.PageWidth - report.Margins.Left - report.Margins.Right;
        var header = new PageHeaderBand { HeightF = 80f };

        var lblSchool = new XRLabel
        {
            Text           = schoolName,
            Font           = new Font("Tahoma", 14, FontStyle.Bold),
            TextAlignment  = TextAlignment.MiddleCenter,
            BoundsF        = new System.Drawing.RectangleF(0, 0, pageWidth, 25),
        };
        var lblContact = new XRLabel
        {
            Text          = contact,
            Font          = new Font("Tahoma", 9),
            TextAlignment = TextAlignment.MiddleCenter,
            BoundsF       = new System.Drawing.RectangleF(0, 26, pageWidth, 18),
        };
        var lblTitle = new XRLabel
        {
            Text          = reportTitle,
            Font          = new Font("Tahoma", 11, FontStyle.Bold),
            TextAlignment = TextAlignment.MiddleCenter,
            BoundsF       = new System.Drawing.RectangleF(0, 46, pageWidth, 22),
        };
        header.Controls.AddRange(new XRControl[] { lblSchool, lblContact, lblTitle });
        report.Bands.Add(header);
    }
}
