using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HoodieStatsApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "Playtime", "UUID" },
                values: new object[,]
                {
                    { 1, "Steve", 120, "uuid-123" },
                    { 2, "Alex", 250, "uuid-456" },
                    { 3, "Herobrine", 9999, "uuid-789" }
                });

            migrationBuilder.InsertData(
                table: "ServerStats",
                columns: new[] { "Id", "ServerBlocksBroken", "ServerBlocksMined", "ServerDeaths", "ServerEconomy", "ServerKills", "ServerPlayers", "ServerPlaytime" },
                values: new object[] { 1, 42000.0, 50000.0, 380.0, 15000.5, 450.0, 150.0, 3000.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServerStats",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
