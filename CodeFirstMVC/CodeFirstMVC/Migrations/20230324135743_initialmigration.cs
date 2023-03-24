using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstMVC.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_salarie",
                columns: table => new
                {
                    Sal_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sal_nom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Sal_age = table.Column<int>(type: "int", nullable: false),
                    Sal_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_salarie", x => x.Sal_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_salarie");
        }
    }
}
