using Microsoft.EntityFrameworkCore.Migrations;

namespace PetrolStation.DataAccess.Migrations
{
    public partial class EditPumpModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pumps_Employees_EmployeeId",
                table: "Pumps");

            migrationBuilder.DropIndex(
                name: "IX_Pumps_EmployeeId",
                table: "Pumps");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Pumps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Pumps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_EmployeeId",
                table: "Pumps",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pumps_Employees_EmployeeId",
                table: "Pumps",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
