using Microsoft.EntityFrameworkCore.Migrations;

namespace BlocXChange.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyNo",
                table: "Fluctuations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyNo",
                table: "Fluctuations");
        }
    }
}
