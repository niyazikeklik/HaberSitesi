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
		public IActionResult HaberEkle(Haber model)
		{
			model.HaberID = 0;
			var x = new DatabaseContext();
			x.Haberler.Add(model);
			x.SaveChanges();
			return AdminPanel();
		}
		public IActionResult HaberGuncelle(Haber model)
		{
			var x = new DatabaseContext();
			x.Haberler.Update(model);
			x.SaveChanges();
			return AdminPanel();
		}
		public IActionResult HaberSil(Haber model)
		{
			var x = new DatabaseContext();
			x.Haberler.Remove(model);
			x.SaveChanges();
			return AdminPanel();
		}
		public IActionResult AdminPanel()
		{
			return View("AdminPanel");
		}
		public IActionResult CikisYap()
		{
			Repos.Login = false;
			var list = API.GetHaberList();
			list.Reverse();
			return View("Index", list);
		}
		public IActionResult GirisYap(Hesap hesap)
		{
			var DBHesap = new DatabaseContext().Hesaplar.FirstOrDefault(x => hesap.UserID == x.UserID && hesap.Pass == x.Pass);
			if (DBHesap != null)
			{
				Repos.Login = true;
				var list = API.GetHaberList();
				list.Reverse();
				return View("Index", list);
			}
			return View("Login", new ErrorResult() { Message = "Kullanıcı adı veya şifre hatalı!" });

		}
		public IActionResult Login()
		{
			return View();
		}
		public IActionResult Kaydol(Hesap hesap)
		{
			var context = new DatabaseContext();
			if (context.Hesaplar.Any(x => hesap.UserID == x.UserID))
				return View("KayıtOl", new ErrorResult() { Message = "Kullanıcı adı kullanılmakta." });
			else
			{
				context.Hesaplar.Add(hesap);
				context.SaveChanges();
				return View("KayıtOl", new ErrorResult() { Message = "Kayıt başarılı." });
			}


		}
		public IActionResult KayıtOL()
		{
			return View();
		}

		[HttpPost]
		public bool Upload()
		{

			if (Request.Form.Files.Count != 0)
			{
				for (int i = 0; i < Request.Form.Files.Count; i++)
				{
					var file = Request.Form.Files[i];
					var fileName = Path.GetFileName(file.FileName);
					var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{fileName}");
					using var stream = new FileStream(path, FileMode.Create);
					file.CopyTo(stream);

				}
				return true;
			}
			return false;
		}
	}
}