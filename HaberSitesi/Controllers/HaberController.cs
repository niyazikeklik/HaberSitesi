using HaberSitesi.Database;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System.Linq;

namespace HaberSitesi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HaberController : ControllerBase
	{
		[HttpGet("GetHaberList")]
		public IActionResult GetHaberList()
		{
			string jsonurl = JsonConvert.SerializeObject(new DatabaseContext().Haberler.ToList());
			return Content(jsonurl);
		}
	}
}
