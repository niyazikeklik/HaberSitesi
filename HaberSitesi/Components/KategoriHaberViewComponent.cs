using HaberSitesi.Database;
using HaberSitesi.Models;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace HaberSitesi.Components
{
	public class KategoriHaberViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(int kategori)
		{
			var kat = ((Kategoriler)kategori);
			var x = new DatabaseContext();
			var y = x.Haberler.Where(x=> x.Kategori == kat).ToList();
			return View(y);
		}
	}
}
