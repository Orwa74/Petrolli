using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetrolStation.DataAccess.Migrations
{
    public partial class EditFuelPriceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fuelprice",
                table: "FuelPrice",
                newName: "SelingPrice");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FuelPrice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FuelTypeId",
                table: "FuelPrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PurrechasingPrice",
                table: "FuelPrice",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_FuelPrice_FuelTypeId",
                table: "FuelPrice",
                column: "FuelTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FuelPrice_FuelTypes_FuelTypeId",
                table: "FuelPrice",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuelPrice_FuelTypes_FuelTypeId",
                table: "FuelPrice");

            migrationBuilder.DropIndex(
                name: "IX_FuelPrice_FuelTypeId",
                table: "FuelPrice");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "FuelPrice");

            migrationBuilder.DropColumn(
                name: "FuelTypeId",
                table: "FuelPrice");

            migrationBuilder.DropColumn(
                name: "PurrechasingPrice",
                table: "FuelPrice");

            migrationBuilder.RenameColumn(
                name: "SelingPrice",
                table: "FuelPrice",
                newName: "Fuelprice");
        }
    }
}
