using Microsoft.EntityFrameworkCore.Migrations;

namespace PetrolStation.DataAccess.Migrations
{
    public partial class EditCrowding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuelTypeId",
                table: "Crowding",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Crowding_FuelTypeId",
                table: "Crowding",
                column: "FuelTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crowding_FuelTypes_FuelTypeId",
                table: "Crowding",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crowding_FuelTypes_FuelTypeId",
                table: "Crowding");

            migrationBuilder.DropIndex(
                name: "IX_Crowding_FuelTypeId",
                table: "Crowding");

            migrationBuilder.DropColumn(
                name: "FuelTypeId",
                table: "Crowding");
        }
    }
}
