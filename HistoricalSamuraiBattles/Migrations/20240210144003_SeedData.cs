using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HistoricalSamuraiBattles.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Battles",
                columns: new[] { "Id", "Date", "Location", "Name" },
                values: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2023, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaza", "Tofan Al-Aqsa" });

            migrationBuilder.InsertData(
                table: "Horses",
                columns: new[] { "Id", "Color", "Height", "Name" },
                values: new object[,]
                {
                    { new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), 1, 2.5, "White Horse" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), 0, 2.1000000000000001, "Black Horse" }
                });

            migrationBuilder.InsertData(
                table: "BattleHorse",
                columns: new[] { "BattlesId", "HorsesId" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") }
                });

            migrationBuilder.InsertData(
                table: "Samurais",
                columns: new[] { "Id", "HorseId", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("80abbca8-664d-4b20-b5de-024705497d4a"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Warrior Samurai", 0 },
                    { new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"), "Trojan Samurai", 2 }
                });

            migrationBuilder.InsertData(
                table: "BattleSamurai",
                columns: new[] { "BattlesId", "SamuraisId" },
                values: new object[,]
                {
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") },
                    { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BattleHorse",
                keyColumns: new[] { "BattlesId", "HorsesId" },
                keyValues: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3") });

            migrationBuilder.DeleteData(
                table: "BattleHorse",
                keyColumns: new[] { "BattlesId", "HorsesId" },
                keyValues: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870") });

            migrationBuilder.DeleteData(
                table: "BattleSamurai",
                keyColumns: new[] { "BattlesId", "SamuraisId" },
                keyValues: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("80abbca8-664d-4b20-b5de-024705497d4a") });

            migrationBuilder.DeleteData(
                table: "BattleSamurai",
                keyColumns: new[] { "BattlesId", "SamuraisId" },
                keyValues: new object[] { new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"), new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a") });

            migrationBuilder.DeleteData(
                table: "Battles",
                keyColumn: "Id",
                keyValue: new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"));

            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: new Guid("80abbca8-664d-4b20-b5de-024705497d4a"));

            migrationBuilder.DeleteData(
                table: "Samurais",
                keyColumn: "Id",
                keyValue: new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"));

            migrationBuilder.DeleteData(
                table: "Horses",
                keyColumn: "Id",
                keyValue: new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"));

            migrationBuilder.DeleteData(
                table: "Horses",
                keyColumn: "Id",
                keyValue: new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"));
        }
    }
}
