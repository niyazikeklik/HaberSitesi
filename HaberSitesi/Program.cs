using HaberSitesi.Database;
using HaberSitesi.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitesi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			using (DatabaseContext client = new())
			{
				client.Database.Migrate();
			}

			var x = new DatabaseContext();
			if (x.Haberler.Count() < 15)
			{
				x.Haberler.RemoveRange(x.Haberler);
				for (int j = 1; j < 3; j++)
					for (int i = 1; i < 30; i++)
					{
						var haber = new Haber()
						{
							Baslik = $"Deneme baþlýk {i * j}",
							Detay = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
							FotoURL = $"news-350x223-{(i%5)+1}.jpg",
							Kategori = (Kategoriler)(i%Enum.GetValues<Kategoriler>().Count()),
						};
						x.Haberler.Add(haber);
					}
				x.SaveChanges();
			}


			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
