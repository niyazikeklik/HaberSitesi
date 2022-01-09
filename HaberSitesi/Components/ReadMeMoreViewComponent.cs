using HaberSitesi.Database;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace HaberSitesi.Components
{
    public class ReadMeMoreViewComponent : ViewComponent
    {
		public IViewComponentResult Invoke()
		{
			var x = new DatabaseContext();
			var y = x.Haberler.ToList();
			var model = y.Take(y.Count - 15).Take(15).ToList();
			return View(model);
		}
	}
}
