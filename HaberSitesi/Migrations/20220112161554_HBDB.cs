using Microsoft.EntityFrameworkCore.Migrations;

namespace HaberSitesi.Migrations
{
    public partial class HBDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haberler",
                columns: table => new
                {
                    HaberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kategori = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haberler", x => x.HaberID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Haberler");
        }
    }
}
