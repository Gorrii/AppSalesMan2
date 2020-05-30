using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSalesMan2.Database.Migrations
{
    public partial class RebuildDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeCompanyNames");

            migrationBuilder.DropTable(
                name: "CustomerSalesManChanges");

            migrationBuilder.CreateTable(
                name: "ChangeRequestDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesManId = table.Column<int>(nullable: false),
                    Parameter = table.Column<string>(nullable: true),
                    NewParameter = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeRequestDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeRequestDatas");

            migrationBuilder.CreateTable(
                name: "ChangeCompanyNames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExistingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SAPnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeCompanyNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSalesManChanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualSalesManLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewSalesManLastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSalesManChanges", x => x.Id);
                });
        }
    }
}
