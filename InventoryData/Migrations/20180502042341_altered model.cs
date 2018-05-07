using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InventoryData.Migrations
{
    public partial class alteredmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MilitaryAssets_RepairingId",
                table: "MilitaryAssets");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryAssets_RepairingId",
                table: "MilitaryAssets",
                column: "RepairingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MilitaryAssets_RepairingId",
                table: "MilitaryAssets");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryAssets_RepairingId",
                table: "MilitaryAssets",
                column: "RepairingId",
                unique: true,
                filter: "[RepairingId] IS NOT NULL");
        }
    }
}
