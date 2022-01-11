using HaberSitesi.Database;
using HaberSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using System.Linq;

namespace HaberSitesi.Components
{
    public class TampleteViewComponent : ViewComponent
    {
		public IViewComponentResult Invoke()
		{
			DatabaseContext context = Repos.app.ApplicationServices
					   .CreateScope().ServiceProvider
					   .GetRequiredService<DatabaseContext>();
			var x = context;
			var y = x.Haberler.ToList().Take(4).ToList();
			return View(y);
		}
	}
}
