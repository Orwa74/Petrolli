using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetrolStation.DataAccess.Migrations
{
    public partial class EditFuelTypemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tanks_FuelTypeId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_FuelPrice_FuelTypeId",
                table: "FuelPrice");

            migrationBuilder.DropIndex(
                name: "IX_Crowdings_FuelTypeId",
                table: "Crowdings");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_FuelTypeId",
                table: "Tanks",
                column: "FuelTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuelPrice_FuelTypeId",
                table: "FuelPrice",
                column: "FuelTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crowdings_FuelTypeId",
                table: "Crowdings",
                column: "FuelTypeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tanks_FuelTypeId",
                table: "Tanks");

            migrationBuilder.DropIndex(
                name: "IX_FuelPrice_FuelTypeId",
                table: "FuelPrice");

            migrationBuilder.DropIndex(
                name: "IX_Crowdings_FuelTypeId",
                table: "Crowdings");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_FuelTypeId",
                table: "Tanks",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelPrice_FuelTypeId",
                table: "FuelPrice",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Crowdings_FuelTypeId",
                table: "Crowdings",
                column: "FuelTypeId");
        }
    }
}
