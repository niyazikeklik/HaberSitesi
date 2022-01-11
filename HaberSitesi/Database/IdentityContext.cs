using HaberSitesi.Models.ViewModels;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HaberSitesi.Database
{
	//IdentityContext bizim admin login işlemlerimizi, kullanıcı hesap bilgilerini tutan veritabanımızı simgeler.
	//IdentityDbContexten kalıtım alarak, aslında IdentityDbContext içerisinde hazır gelen bir çok tabloyu otomatik olarak eklemiş oluyoruz.
	//IdentityDbContext sınıfı microsoftun bize sunduğu içerisinde çeşitli tablolar olan hazır bir sınıftır
	//Kullanıcı login ve autharize işlemlerini kolaylaşmasını sağlamaktadır.
	public class IdentityContext : IdentityDbContext<IdentityUser>
	{
		public IdentityContext(DbContextOptions<IdentityContext> options)
				 : base(options) { }
	}
}
