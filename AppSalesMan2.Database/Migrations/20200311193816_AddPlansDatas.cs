using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSalesMan2.Database.Migrations
{
    public partial class AddPlansDatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plansDatas",
                columns: table => new
                {
                    PlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesManId = table.Column<int>(nullable: false),
                    PlanValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plansDatas", x => x.PlanID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plansDatas");
        }
    }
}
