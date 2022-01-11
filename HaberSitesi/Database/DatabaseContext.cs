using HaberSitesi.Models;

using Microsoft.EntityFrameworkCore;

namespace HaberSitesi.Database
{
    public class DatabaseContext : DbContext
    {
        //DatabaseContext sınıfı genel olarak veritabanını simgeler, veritabanı içinde bulunan tablolara databasecontext sınıfı üzerinden ulaşabiliriz.
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {
        }

        //Veritabanındaki haberler tablosunu simgeler
        //get ve set methodları üzerinden veritabanındaki haberler tablosuna ekleme, silme, güncelleme, listeleme gibi işlemler yaptırılabilir.
        public DbSet<Haber> Haberler { get; set; }
    }
}
