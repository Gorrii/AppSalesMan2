using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSalesMan2.Database.Migrations
{
    public partial class AddColumInCustomerData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "CustomerDatas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logistic",
                table: "CustomerDatas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Industry",
                table: "CustomerDatas");

            migrationBuilder.DropColumn(
                name: "Logistic",
                table: "CustomerDatas");
        }
    }
}
