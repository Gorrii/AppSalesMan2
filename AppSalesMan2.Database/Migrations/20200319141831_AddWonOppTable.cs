using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSalesMan2.Database.Migrations
{
    public partial class AddWonOppTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WonOppDatas",
                columns: table => new
                {
                    WonOppId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesManId = table.Column<int>(nullable: false),
                    WonOppName = table.Column<string>(nullable: true),
                    WonOppEndCustomer = table.Column<string>(nullable: true),
                    EstimatedOIDate = table.Column<string>(nullable: true),
                    WonOppVolumen = table.Column<double>(nullable: false),
                    Accepted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WonOppDatas", x => x.WonOppId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WonOppDatas");
        }
    }
}
