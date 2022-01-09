using HaberSitesi.Database;
using HaberSitesi.Models;
using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace HaberSitesi.Components
{
    public class TampleteViewComponent : ViewComponent
    {
		public IViewComponentResult Invoke()
		{
			var x = new DatabaseContext();
			var y = x.Haberler.ToList().Take(4).ToList();
			return View(y);
		}
	}
}
