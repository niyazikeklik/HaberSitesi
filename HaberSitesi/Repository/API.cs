using HaberSitesi.Models;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace HaberSitesi
{
	public static class API
	{
		public static string baseurl = "";
		public static List<Haber> GetHaberList()
		{
		
			using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
			{
				if (!baseurl.StartsWith("http"))
					baseurl = @"https://" + baseurl;
				client.BaseAddress = new Uri(baseurl);
				HttpResponseMessage response = client.GetAsync("api/Haber/GetHaberList").Result;
				response.EnsureSuccessStatusCode();
				string result = response.Content.ReadAsStringAsync().Result;
				return JsonConvert.DeserializeObject<List<Haber>>(result);
			}

		}
	}
}
