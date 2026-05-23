using System.IO;
using System.Net;
using System.Text;

namespace AlienAge.ExtremeMessenger;

public class KigingeSMSSender
{
	public static string SendSMS(string message, string receiver)
	{
		string text = "username=256752162444";
		text += "&password=kampala";
		text = text + "&message=" + message;
		text += "&from=\nKibinge";
		text = text + "&recipients=" + receiver;
		text += "&type=";
		string requestUriString = "http://smshour.com/smsserver/bulksms-api.php";
		HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
		httpWebRequest.Method = "POST";
		byte[] bytes = Encoding.ASCII.GetBytes(text);
		httpWebRequest.ContentType = "application/x-www-form-urlencoded";
		httpWebRequest.ContentLength = bytes.Length;
		Stream requestStream = httpWebRequest.GetRequestStream();
		requestStream.Write(bytes, 0, bytes.Length);
		requestStream.Close();
		HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
		Stream responseStream = httpWebResponse.GetResponseStream();
		StreamReader streamReader = new StreamReader(responseStream, Encoding.Default);
		string text2 = streamReader.ReadToEnd();
		streamReader.Close();
		responseStream.Close();
		httpWebResponse.Close();
		return httpWebResponse.StatusCode.ToString();
	}
}
