using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetrolStation.DataAccess.Migrations
{
    public partial class EditUserLoginModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FuelPrice_FuelTypeId",
                table: "FuelPrice");

            migrationBuilder.CreateIndex(
                name: "IX_FuelPrice_FuelTypeId",
                table: "FuelPrice",
                column: "FuelTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FuelPrice_FuelTypeId",
                table: "FuelPrice");

            migrationBuilder.CreateIndex(
                name: "IX_FuelPrice_FuelTypeId",
                table: "FuelPrice",
                column: "FuelTypeId",
                unique: true);
        }
    }
}
