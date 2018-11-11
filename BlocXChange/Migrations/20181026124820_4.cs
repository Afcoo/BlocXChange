using Microsoft.EntityFrameworkCore.Migrations;

namespace BlocXChange.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StockNo",
                table: "Stocks",
                newName: "DataNo");

            migrationBuilder.RenameColumn(
                name: "GameNO",
                table: "Games",
                newName: "GameNo");

            migrationBuilder.RenameColumn(
                name: "FlucNo",
                table: "Fluctuations",
                newName: "DataNo");

            migrationBuilder.RenameColumn(
                name: "ExchangeDataNo",
                table: "Exchanges",
                newName: "DataNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataNo",
                table: "Stocks",
                newName: "StockNo");

            migrationBuilder.RenameColumn(
                name: "GameNo",
                table: "Games",
                newName: "GameNO");

            migrationBuilder.RenameColumn(
                name: "DataNo",
                table: "Fluctuations",
                newName: "FlucNo");

            migrationBuilder.RenameColumn(
                name: "DataNo",
                table: "Exchanges",
                newName: "ExchangeDataNo");
        }
    }
}
