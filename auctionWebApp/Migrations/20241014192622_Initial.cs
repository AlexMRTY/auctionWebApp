using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace auctionWebApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AuctionItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    StartingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClosingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserName = table.Column<string>(type: "longtext", nullable: false),
                    IsOpen = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionItem", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "longtext", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlacedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AuctionItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bid_AuctionItem_AuctionItemId",
                        column: x => x.AuctionItemId,
                        principalTable: "AuctionItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AuctionItem",
                columns: new[] { "Id", "ClosingPrice", "Description", "EndTime", "IsOpen", "Name", "StartTime", "StartingPrice", "UserName" },
                values: new object[] { -1, 0m, "A red bicycle", new DateTime(2024, 10, 17, 21, 26, 21, 850, DateTimeKind.Local).AddTicks(7836), true, "Bicycle", new DateTime(2024, 10, 14, 21, 26, 21, 850, DateTimeKind.Local).AddTicks(7789), 100m, "alexmrty" });

            migrationBuilder.InsertData(
                table: "Bid",
                columns: new[] { "Id", "Amount", "AuctionItemId", "PlacedTime", "UserName" },
                values: new object[,]
                {
                    { -2, 200m, -1, new DateTime(2024, 10, 14, 21, 26, 21, 850, DateTimeKind.Local).AddTicks(8024), "anderslm" },
                    { -1, 150m, -1, new DateTime(2024, 10, 14, 21, 26, 21, 850, DateTimeKind.Local).AddTicks(8015), "alexmrty" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bid_AuctionItemId",
                table: "Bid",
                column: "AuctionItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "AuctionItem");
        }
    }
}
