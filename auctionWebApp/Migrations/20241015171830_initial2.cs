using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace auctionWebApp.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionItem",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 18, 19, 18, 29, 831, DateTimeKind.Local).AddTicks(4993), new DateTime(2024, 10, 15, 19, 18, 29, 831, DateTimeKind.Local).AddTicks(4936) });

            migrationBuilder.UpdateData(
                table: "Bid",
                keyColumn: "Id",
                keyValue: -2,
                column: "PlacedTime",
                value: new DateTime(2024, 10, 15, 19, 18, 29, 831, DateTimeKind.Local).AddTicks(5124));

            migrationBuilder.UpdateData(
                table: "Bid",
                keyColumn: "Id",
                keyValue: -1,
                column: "PlacedTime",
                value: new DateTime(2024, 10, 15, 19, 18, 29, 831, DateTimeKind.Local).AddTicks(5120));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionItem",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 10, 17, 21, 26, 21, 850, DateTimeKind.Local).AddTicks(7836), new DateTime(2024, 10, 14, 21, 26, 21, 850, DateTimeKind.Local).AddTicks(7789) });

            migrationBuilder.UpdateData(
                table: "Bid",
                keyColumn: "Id",
                keyValue: -2,
                column: "PlacedTime",
                value: new DateTime(2024, 10, 14, 21, 26, 21, 850, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "Bid",
                keyColumn: "Id",
                keyValue: -1,
                column: "PlacedTime",
                value: new DateTime(2024, 10, 14, 21, 26, 21, 850, DateTimeKind.Local).AddTicks(8015));
        }
    }
}
