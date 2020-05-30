using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSalesMan2.Database.Migrations
{
    public partial class AddIndirectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndirectDatas",
                columns: table => new
                {
                    IndirectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DystrCustomer = table.Column<string>(nullable: true),
                    SalesManId = table.Column<int>(nullable: false),
                    Quarter = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Volumen = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndirectDatas", x => x.IndirectID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndirectDatas");
        }
    }
}
