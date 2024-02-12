using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HistoricalSamuraiBattles.Migrations
{
    /// <inheritdoc />
    public partial class changeSamurai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Horses_HorseId",
                table: "Samurais");

            migrationBuilder.AlterColumn<Guid>(
                name: "HorseId",
                table: "Samurais",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Horses_HorseId",
                table: "Samurais",
                column: "HorseId",
                principalTable: "Horses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Samurais_Horses_HorseId",
                table: "Samurais");

            migrationBuilder.AlterColumn<Guid>(
                name: "HorseId",
                table: "Samurais",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Samurais_Horses_HorseId",
                table: "Samurais",
                column: "HorseId",
                principalTable: "Horses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
