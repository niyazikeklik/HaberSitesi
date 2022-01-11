using HaberSitesi.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

using System.Linq;

namespace HaberSitesi.Controllers
{
	//Api controller'dır
	[Route("api/[controller]")]
	[ApiController]
	public class HaberController : ControllerBase
	{
		[HttpGet("GetHaberList")]
		public IActionResult GetHaberList()
		{
			//Bu method çağrıldığında veritabanındaki haberler tablosunu olduğu gibi alıp json fomatında bir string olarak döner
			DatabaseContext context = Repos.app.ApplicationServices
					.CreateScope().ServiceProvider
					.GetRequiredService<DatabaseContext>();
			string jsonurl = JsonConvert.SerializeObject(context.Haberler.ToList());
			return Content(jsonurl);
		}
	}
}
