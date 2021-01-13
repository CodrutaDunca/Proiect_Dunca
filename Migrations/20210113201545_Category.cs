using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Dunca.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Clothe",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clothe_CategoryID",
                table: "Clothe",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothe_Category_CategoryID",
                table: "Clothe",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothe_Category_CategoryID",
                table: "Clothe");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Clothe_CategoryID",
                table: "Clothe");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Clothe");
        }
    }
}
