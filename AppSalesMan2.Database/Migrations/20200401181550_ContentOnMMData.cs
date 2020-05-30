using Microsoft.EntityFrameworkCore.Migrations;

namespace AppSalesMan2.Database.Migrations
{
    public partial class ContentOnMMData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentOnMMDatas",
                columns: table => new
                {
                    ContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesManId = table.Column<int>(nullable: false),
                    HighLights = table.Column<string>(nullable: true),
                    LowLights = table.Column<string>(nullable: true),
                    CriticalIssue = table.Column<string>(nullable: true),
                    GeneralTopic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentOnMMDatas", x => x.ContentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentOnMMDatas");
        }
    }
}
