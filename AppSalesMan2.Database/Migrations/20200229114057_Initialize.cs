using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSalesMan2.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChangeCompanyNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SAPnumber = table.Column<int>(nullable: false),
                    ExistingName = table.Column<string>(nullable: true),
                    NewName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeCompanyNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDatas",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SAP = table.Column<int>(nullable: false),
                    IFA = table.Column<int>(nullable: false),
                    Postcode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    SalesManID = table.Column<int>(nullable: false),
                    RequestForChange = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDatas", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerSalesManChanges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualSalesManLastName = table.Column<string>(nullable: true),
                    NewSalesManLastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSalesManChanges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesManDatas",
                columns: table => new
                {
                    SalesManID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Menager = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesManDatas", x => x.SalesManID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeCompanyNames");

            migrationBuilder.DropTable(
                name: "CustomerDatas");

            migrationBuilder.DropTable(
                name: "CustomerSalesManChanges");

            migrationBuilder.DropTable(
                name: "SalesManDatas");
        }
    }
}
