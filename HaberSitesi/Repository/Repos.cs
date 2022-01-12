using Microsoft.AspNetCore.Builder;

using System.IO;

namespace HaberSitesi
{
	public static class Repos
	{
		public static IApplicationBuilder app;
		public static bool Login = false;
	}
}
//AZURE SQL SERVER
//Server=tcp:dbserverhaber.database.windows.net,1433;Initial Catalog=haberSitesiDB;Persist Security Info=False;User ID=niyazi;Password=Pas12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;

//localDB
//Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=haberSitesiDB;Integrated Security=SSPI;
