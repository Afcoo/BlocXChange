using Microsoft.EntityFrameworkCore.Migrations;

namespace BlocXChange.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameNo",
                table: "Exchanges",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Exchanges_GameNo",
                table: "Exchanges",
                column: "GameNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchanges_Games_GameNo",
                table: "Exchanges",
                column: "GameNo",
                principalTable: "Games",
                principalColumn: "GameNO",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchanges_Games_GameNo",
                table: "Exchanges");

            migrationBuilder.DropIndex(
                name: "IX_Exchanges_GameNo",
                table: "Exchanges");

            migrationBuilder.DropColumn(
                name: "GameNo",
                table: "Exchanges");
        }
    }
}
