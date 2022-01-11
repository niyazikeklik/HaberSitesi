using HaberSitesi.Database;
using HaberSitesi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using System.Linq;

namespace HaberSitesi.Components
{
	public class KategoriHaberViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(int kategori)
		{
			var kat = ((Kategoriler)kategori);
			DatabaseContext context = Repos.app.ApplicationServices
					.CreateScope().ServiceProvider
					.GetRequiredService<DatabaseContext>();
			var x = context;
			var y = x.Haberler.Where(x=> x.Kategori == kat).ToList();
			return View(y);
		}
	}
}
