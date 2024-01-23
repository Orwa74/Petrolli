using Microsoft.EntityFrameworkCore.Migrations;

namespace PetrolStation.DataAccess.Migrations
{
    public partial class UpdateCashBoxModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crowding_FuelTypes_FuelTypeId",
                table: "Crowding");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelAddition_FuelTypes_FuelTypeId",
                table: "FuelAddition");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelAddition_Tanks_TankId",
                table: "FuelAddition");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelRequest_FuelTypes_FuelTypeId",
                table: "FuelRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelRequest_Suppliers_SupplierId",
                table: "FuelRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelRequest",
                table: "FuelRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelAddition",
                table: "FuelAddition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crowding",
                table: "Crowding");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashBox",
                table: "CashBox");

            migrationBuilder.RenameTable(
                name: "FuelRequest",
                newName: "FuelRequests");

            migrationBuilder.RenameTable(
                name: "FuelAddition",
                newName: "FuelAdditions");

            migrationBuilder.RenameTable(
                name: "Crowding",
                newName: "Crowdings");

            migrationBuilder.RenameTable(
                name: "CashBox",
                newName: "CashBoxs");

            migrationBuilder.RenameIndex(
                name: "IX_FuelRequest_SupplierId",
                table: "FuelRequests",
                newName: "IX_FuelRequests_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_FuelRequest_FuelTypeId",
                table: "FuelRequests",
                newName: "IX_FuelRequests_FuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FuelAddition_TankId",
                table: "FuelAdditions",
                newName: "IX_FuelAdditions_TankId");

            migrationBuilder.RenameIndex(
                name: "IX_FuelAddition_FuelTypeId",
                table: "FuelAdditions",
                newName: "IX_FuelAdditions_FuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Crowding_FuelTypeId",
                table: "Crowdings",
                newName: "IX_Crowdings_FuelTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CashBoxs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelRequests",
                table: "FuelRequests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelAdditions",
                table: "FuelAdditions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crowdings",
                table: "Crowdings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashBoxs",
                table: "CashBoxs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Crowdings_FuelTypes_FuelTypeId",
                table: "Crowdings",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelAdditions_FuelTypes_FuelTypeId",
                table: "FuelAdditions",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelAdditions_Tanks_TankId",
                table: "FuelAdditions",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelRequests_FuelTypes_FuelTypeId",
                table: "FuelRequests",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelRequests_Suppliers_SupplierId",
                table: "FuelRequests",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crowdings_FuelTypes_FuelTypeId",
                table: "Crowdings");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelAdditions_FuelTypes_FuelTypeId",
                table: "FuelAdditions");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelAdditions_Tanks_TankId",
                table: "FuelAdditions");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelRequests_FuelTypes_FuelTypeId",
                table: "FuelRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FuelRequests_Suppliers_SupplierId",
                table: "FuelRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelRequests",
                table: "FuelRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuelAdditions",
                table: "FuelAdditions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crowdings",
                table: "Crowdings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashBoxs",
                table: "CashBoxs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CashBoxs");

            migrationBuilder.RenameTable(
                name: "FuelRequests",
                newName: "FuelRequest");

            migrationBuilder.RenameTable(
                name: "FuelAdditions",
                newName: "FuelAddition");

            migrationBuilder.RenameTable(
                name: "Crowdings",
                newName: "Crowding");

            migrationBuilder.RenameTable(
                name: "CashBoxs",
                newName: "CashBox");

            migrationBuilder.RenameIndex(
                name: "IX_FuelRequests_SupplierId",
                table: "FuelRequest",
                newName: "IX_FuelRequest_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_FuelRequests_FuelTypeId",
                table: "FuelRequest",
                newName: "IX_FuelRequest_FuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FuelAdditions_TankId",
                table: "FuelAddition",
                newName: "IX_FuelAddition_TankId");

            migrationBuilder.RenameIndex(
                name: "IX_FuelAdditions_FuelTypeId",
                table: "FuelAddition",
                newName: "IX_FuelAddition_FuelTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Crowdings_FuelTypeId",
                table: "Crowding",
                newName: "IX_Crowding_FuelTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelRequest",
                table: "FuelRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuelAddition",
                table: "FuelAddition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crowding",
                table: "Crowding",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashBox",
                table: "CashBox",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Crowding_FuelTypes_FuelTypeId",
                table: "Crowding",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelAddition_FuelTypes_FuelTypeId",
                table: "FuelAddition",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelAddition_Tanks_TankId",
                table: "FuelAddition",
                column: "TankId",
                principalTable: "Tanks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelRequest_FuelTypes_FuelTypeId",
                table: "FuelRequest",
                column: "FuelTypeId",
                principalTable: "FuelTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FuelRequest_Suppliers_SupplierId",
                table: "FuelRequest",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
