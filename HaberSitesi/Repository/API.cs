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
		
			//HttpClient ile istekte bulunacak bir istemci oluşturuyoruz.
			using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
			{
				if (!baseurl.StartsWith("http"))
					baseurl = @"https://" + baseurl;
				//Oluşturuduğumuz işlemci nesnesi ile ilgili adrese bir request atıyoruz.
				client.BaseAddress = new Uri(baseurl);
				
				HttpResponseMessage response = client.GetAsync("api/Haber/GetHaberList").Result;
				//Attığımız rqeuest sonucu bize dönen response data Json formatında bir string ifadedir
				response.EnsureSuccessStatusCode();
				//response'da dönen string veriyi okuyoruz.
				string result = response.Content.ReadAsStringAsync().Result;
				//Ve json formatındai string data'yı List<Haber> şekline çeviriyoruz.
				return JsonConvert.DeserializeObject<List<Haber>>(result);
			}

		}
	}
}
