using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSalesMan2.Database.Migrations
{
    public partial class AddColumnCompanyID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "ChangeRequestDatas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "ChangeRequestDatas");
        }
    }
}
