using HaberSitesi.Database;
using HaberSitesi.Models;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HaberSitesi.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
		{
			_logger = logger;
			_httpContextAccessor = httpContextAccessor;
			API.baseurl = _httpContextAccessor.HttpContext.Request.Host.Value;
		}

		public IActionResult Index()
		{
			var list = API.GetHaberList();
			list.Reverse();
			return View(list);
		}
		public IActionResult HaberDetay(int id)
		{
			var x = API.GetHaberList().First(x => x.HaberID == id);
			return View(x);
		}

		public IActionResult Login()
		{
			return View();
		}

	}
}