using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InventoryData.Migrations
{
    public partial class UpdatedVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Vehicle_HasShields",
                table: "MilitaryAssets",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Vehicle_HasShields",
                table: "MilitaryAssets",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
