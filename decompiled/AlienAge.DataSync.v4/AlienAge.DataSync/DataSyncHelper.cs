using System.IO;
using System.Net;

namespace AlienAge.DataSync;

public class DataSyncHelper
{
	public static string UrlString => "https://sims.surepayltd.com";

	public static string ApiKey => "111f942a-0c00-4bb8-ac95-f514e2229066";

	public static string StudentExists(string StudentNo)
	{
		string requestUriString = UrlString + "/api/student/" + StudentNo;
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
		httpWebRequest.Accept = "application/json";
		httpWebRequest.Headers["6CD14B34-E080-4AEC-995A-0BC03CCABE6B"] = ApiKey;
		string result = string.Empty;
		try
		{
			using HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
			{
				string text = streamReader.ReadToEnd();
			}
			result = httpWebResponse.StatusCode.ToString();
		}
		catch (WebException ex)
		{
			result = ex.Message;
		}
		return result;
	}
}
