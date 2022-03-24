using Microsoft.EntityFrameworkCore.Migrations;

namespace GuideBookProject.Migrations
{
    public partial class InitGuideBookDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VarChar(20)", nullable: true),
                    Surname = table.Column<string>(type: "VarChar(20)", nullable: true),
                    Company = table.Column<string>(type: "VarChar(20)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "CommInfos",
                columns: table => new
                {
                    CommInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "VarChar(40)", nullable: true),
                    Location = table.Column<string>(type: "VarChar(30)", nullable: true),
                    TelNo = table.Column<string>(type: "VarChar(12)", nullable: true),
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommInfos", x => x.CommInfoID);
                    table.ForeignKey(
                        name: "FK_CommInfos_Persons_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Persons",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommInfos_PersonID",
                table: "CommInfos",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommInfos");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
