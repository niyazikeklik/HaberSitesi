using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using HaberSitesi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Radzen;
using HaberSitesi.Database;
using System.Linq;
using System;

namespace HaberSitesi
{
    public class Startup
    {

        // string sql = @"Server=tcp:dbserverhaber.database.windows.net,1433;Initial Catalog=haberSitesiDB;Persist Security Info=False;User ID=niyazi;Password=Pas12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=120;";
        string sql = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=haberSitesiDB;Integrated Security=SSPI;";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           // string sql = Configuration.GetConnectionString("DatabaseContext");
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            services.AddScoped<TooltipService>();
            services.AddScoped<ContextMenuService>();

            services.AddDbContext<IdentityContext>(options =>
             options.UseSqlServer(sql));
            services.AddIdentity<IdentityUser, IdentityRole>()
             .AddEntityFrameworkStores<IdentityContext>();
            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(sql));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            Repos.app = app;
            var context = Repos.app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<DatabaseContext>();
            //ÝNTERNETE BAÐLI OLMANIZ GEREKÝR!!!!!!!
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            var context2 = Repos.app.ApplicationServices
           .CreateScope().ServiceProvider
           .GetRequiredService<IdentityContext>();
            if (context2.Database.GetPendingMigrations().Any())
            {
                context2.Database.Migrate();
            }
			if (!context2.Users.Any())
			{
                IdentityUser user = new IdentityUser
                {
                    NormalizedUserName = "admin",
                    NormalizedEmail = "admin",
                    UserName = "admin",
                    PasswordHash = "AQAAAAEAACcQAAAAEKmwahTTmxu5PlCgR9v+SqGEF/9Z/sYH/ErSI+XglQKqBqyj2RmNx8WFPQ6Jsuka+g=="
                };
                context2.Users.Add(user);
                context2.SaveChanges();
			}
            var x = context;
            if (x.Haberler.Count() < 15)
            {
                x.Haberler.RemoveRange(x.Haberler);
                for (int j = 1; j < 3; j++)
                    for (int i = 1; i < 30; i++)
                    {
                        var haber = new Haber()
                        {
                            Baslik = $"Deneme baþlýk {i * j}",
                            Detay = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            FotoURL = $"news-350x223-{(i % 5) + 1}.jpg",
                            Kategori = (Kategoriler)(i % Enum.GetValues<Kategoriler>().Count()),
                        };
                        x.Haberler.Add(haber);
                    }
                x.SaveChanges();
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });
        }
    }
}