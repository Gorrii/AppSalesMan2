using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSalesMan2.Database.Migrations
{
    public partial class AddTableCustomerVolumen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customersVolumenDatas",
                columns: table => new
                {
                    VolumenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    OI = table.Column<double>(nullable: false),
                    Rev = table.Column<double>(nullable: false),
                    BV = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customersVolumenDatas", x => x.VolumenID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customersVolumenDatas");
        }
    }
}
