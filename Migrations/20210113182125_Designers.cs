using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Dunca.Migrations
{
    public partial class Designers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignerID",
                table: "Clothe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Designer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designer", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothe_DesignerID",
                table: "Clothe",
                column: "DesignerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothe_Designer_DesignerID",
                table: "Clothe",
                column: "DesignerID",
                principalTable: "Designer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothe_Designer_DesignerID",
                table: "Clothe");

            migrationBuilder.DropTable(
                name: "Designer");

            migrationBuilder.DropIndex(
                name: "IX_Clothe_DesignerID",
                table: "Clothe");

            migrationBuilder.DropColumn(
                name: "DesignerID",
                table: "Clothe");
        }
    }
}
