using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitGruppen.Data.Migrations
{
    /// <inheritdoc />
    public partial class garage3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    PersNr = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.PersNr);
                });

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrOfSpaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Arrived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfWheels = table.Column<int>(type: "int", nullable: false),
                    vehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    memberPersNr = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.LicensePlate);
                    table.ForeignKey(
                        name: "FK_Vehicle_Member_memberPersNr",
                        column: x => x.memberPersNr,
                        principalTable: "Member",
                        principalColumn: "PersNr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleType_vehicleTypeId",
                        column: x => x.vehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_memberPersNr",
                table: "Vehicle",
                column: "memberPersNr");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_vehicleTypeId",
                table: "Vehicle",
                column: "vehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "VehicleType");
        }
    }
}
