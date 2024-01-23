using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetrolStation.DataAccess.Migrations
{
    public partial class AddDateToCustomerMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SendTime",
                table: "CustomerMessage",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendTime",
                table: "CustomerMessage");
        }
    }
}
