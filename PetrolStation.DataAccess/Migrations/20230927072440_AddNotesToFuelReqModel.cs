using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetrolStation.DataAccess.Migrations
{
    public partial class AddNotesToFuelReqModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "FuelRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "FuelRequests");
        }
    }
}
