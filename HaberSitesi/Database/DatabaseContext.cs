using HaberSitesi.Models;

using Microsoft.EntityFrameworkCore;

namespace HaberSitesi.Database
{
    public class DatabaseContext : DbContext
    {
       // string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=HaberSitesiDB;Integrated Security=True";
        string connectionString = @"Server=tcp:dbserverhaber.database.windows.net,1433;Initial Catalog=haberSitesiDB;Persist Security Info=False;User ID=niyazi;Password=Pas12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString).EnableDetailedErrors();
        }
        public DbSet<Haber> Haberler { get; set; }
        public DbSet<Hesap> Hesaplar { get; set; }
    }
}
