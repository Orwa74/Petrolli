using Microsoft.EntityFrameworkCore.Migrations;

namespace PetrolStation.DataAccess.Migrations
{
    public partial class EditEndShiftModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndShift_CashBoxs_CashBoxId",
                table: "EndShift");

            migrationBuilder.DropForeignKey(
                name: "FK_EndShift_Employees_EmployeeId",
                table: "EndShift");

            migrationBuilder.DropForeignKey(
                name: "FK_EndShift_Pumps_PumpId",
                table: "EndShift");

            migrationBuilder.DropForeignKey(
                name: "FK_EndShift_Shifts_ShiftId",
                table: "EndShift");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EndShift",
                table: "EndShift");

            migrationBuilder.RenameTable(
                name: "EndShift",
                newName: "EndShifts");

            migrationBuilder.RenameIndex(
                name: "IX_EndShift_ShiftId",
                table: "EndShifts",
                newName: "IX_EndShifts_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_EndShift_PumpId",
                table: "EndShifts",
                newName: "IX_EndShifts_PumpId");

            migrationBuilder.RenameIndex(
                name: "IX_EndShift_EmployeeId",
                table: "EndShifts",
                newName: "IX_EndShifts_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EndShift_CashBoxId",
                table: "EndShifts",
                newName: "IX_EndShifts_CashBoxId");

            migrationBuilder.AddColumn<int>(
                name: "PumpMeter",
                table: "EndShifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EndShifts",
                table: "EndShifts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EndShifts_CashBoxs_CashBoxId",
                table: "EndShifts",
                column: "CashBoxId",
                principalTable: "CashBoxs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndShifts_Employees_EmployeeId",
                table: "EndShifts",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndShifts_Pumps_PumpId",
                table: "EndShifts",
                column: "PumpId",
                principalTable: "Pumps",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EndShifts_Shifts_ShiftId",
                table: "EndShifts",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndShifts_CashBoxs_CashBoxId",
                table: "EndShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_EndShifts_Employees_EmployeeId",
                table: "EndShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_EndShifts_Pumps_PumpId",
                table: "EndShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_EndShifts_Shifts_ShiftId",
                table: "EndShifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EndShifts",
                table: "EndShifts");

            migrationBuilder.DropColumn(
                name: "PumpMeter",
                table: "EndShifts");

            migrationBuilder.RenameTable(
                name: "EndShifts",
                newName: "EndShift");

            migrationBuilder.RenameIndex(
                name: "IX_EndShifts_ShiftId",
                table: "EndShift",
                newName: "IX_EndShift_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_EndShifts_PumpId",
                table: "EndShift",
                newName: "IX_EndShift_PumpId");

            migrationBuilder.RenameIndex(
                name: "IX_EndShifts_EmployeeId",
                table: "EndShift",
                newName: "IX_EndShift_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EndShifts_CashBoxId",
                table: "EndShift",
                newName: "IX_EndShift_CashBoxId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EndShift",
                table: "EndShift",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EndShift_CashBoxs_CashBoxId",
                table: "EndShift",
                column: "CashBoxId",
                principalTable: "CashBoxs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndShift_Employees_EmployeeId",
                table: "EndShift",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndShift_Pumps_PumpId",
                table: "EndShift",
                column: "PumpId",
                principalTable: "Pumps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EndShift_Shifts_ShiftId",
                table: "EndShift",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
