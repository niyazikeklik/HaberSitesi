using HaberSitesi.Database;

using Microsoft.AspNetCore.Mvc;

using System.Linq;

namespace HaberSitesi.Components
{
	public class HaberGridViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(API.GetHaberList().TakeLast(15).Reverse().ToList());
		}
	}
}
