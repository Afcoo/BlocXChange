using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlocXChange.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    ExchangeDataNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Seller = table.Column<int>(nullable: false),
                    Buyer = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.ExchangeDataNo);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameNO = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GameID = table.Column<string>(nullable: false),
                    GameKey = table.Column<string>(nullable: false),
                    InitialTime = table.Column<DateTime>(nullable: false),
                    SuspendedTicks = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameNO);
                });

            migrationBuilder.CreateTable(
                name: "Fluctuations",
                columns: table => new
                {
                    FlucNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlucTimeTicks = table.Column<long>(nullable: false),
                    FlucValue = table.Column<int>(nullable: false),
                    GameNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluctuations", x => x.FlucNo);
                    table.ForeignKey(
                        name: "FK_Fluctuations_Games_GameNo",
                        column: x => x.GameNo,
                        principalTable: "Games",
                        principalColumn: "GameNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyNo = table.Column<int>(nullable: false),
                    StockValue = table.Column<int>(nullable: false),
                    GameNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockNo);
                    table.ForeignKey(
                        name: "FK_Stocks_Games_GameNo",
                        column: x => x.GameNo,
                        principalTable: "Games",
                        principalColumn: "GameNO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluctuations_GameNo",
                table: "Fluctuations",
                column: "GameNo");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_GameNo",
                table: "Stocks",
                column: "GameNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exchanges");

            migrationBuilder.DropTable(
                name: "Fluctuations");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
