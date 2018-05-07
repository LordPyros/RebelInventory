using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InventoryData.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountUnderRepair = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageLocations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MilitaryAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RepairingId = table.Column<int>(nullable: true),
                    HasShields = table.Column<bool>(nullable: true),
                    NoOfConcussionMissileLaunchers = table.Column<int>(nullable: true),
                    NoOfIonCannons = table.Column<int>(nullable: true),
                    NoOfLasersCannons = table.Column<int>(nullable: true),
                    NoOfProtonTorpedoLaunchers = table.Column<int>(nullable: true),
                    Vehicle_HasShields = table.Column<int>(nullable: true),
                    MaxPassengers = table.Column<int>(nullable: true),
                    Vehicle_NoOfLasersCannons = table.Column<int>(nullable: true),
                    IsOneHanded = table.Column<bool>(nullable: true),
                    IsTripodMounted = table.Column<bool>(nullable: true),
                    IsTwoHanded = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MilitaryAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MilitaryAssets_StorageLocations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "StorageLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MilitaryAssets_Repairs_RepairingId",
                        column: x => x.RepairingId,
                        principalTable: "Repairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryAssets_LocationId",
                table: "MilitaryAssets",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryAssets_RepairingId",
                table: "MilitaryAssets",
                column: "RepairingId",
                unique: true,
                filter: "[RepairingId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MilitaryAssets");

            migrationBuilder.DropTable(
                name: "StorageLocations");

            migrationBuilder.DropTable(
                name: "Repairs");
        }
    }
}
