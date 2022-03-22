using Microsoft.EntityFrameworkCore.Migrations;

namespace GuideBookProject.Migrations
{
    public partial class CommInfoModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelNo",
                table: "CommInfos",
                type: "VarChar(12)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelNo",
                table: "CommInfos");
        }
    }
}
