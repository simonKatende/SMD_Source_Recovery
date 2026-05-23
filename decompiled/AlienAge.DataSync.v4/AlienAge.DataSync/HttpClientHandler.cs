using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AlienAge.DataSync;

public class HttpClientHandler : HttpClient
{
	public HttpClientHandler()
	{
		((HttpClient)this).BaseAddress = new Uri("https://sims.surepayltd.com");
		((HttpHeaders)((HttpClient)this).DefaultRequestHeaders).Add("Accept", "application/json");
		((HttpHeaders)((HttpClient)this).DefaultRequestHeaders).Add("6CD14B34-E080-4AEC-995A-0BC03CCABE6B", DataSyncHelper.ApiKey);
	}
}
