using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitGruppen.Data.Migrations
{
    /// <inheritdoc />
    public partial class DBContextUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Member_memberPersNr",
                table: "Vehicle");

            migrationBuilder.AlterColumn<string>(
                name: "memberPersNr",
                table: "Vehicle",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "ParkingSpot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpotName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vehicleLicensePlate = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSpot_Vehicle_vehicleLicensePlate",
                        column: x => x.vehicleLicensePlate,
                        principalTable: "Vehicle",
                        principalColumn: "LicensePlate");
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeDeparture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeArrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCost = table.Column<double>(type: "float", nullable: false),
                    vehicleLicensePlate = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_Vehicle_vehicleLicensePlate",
                        column: x => x.vehicleLicensePlate,
                        principalTable: "Vehicle",
                        principalColumn: "LicensePlate",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpot_vehicleLicensePlate",
                table: "ParkingSpot",
                column: "vehicleLicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_vehicleLicensePlate",
                table: "Receipt",
                column: "vehicleLicensePlate");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Member_memberPersNr",
                table: "Vehicle",
                column: "memberPersNr",
                principalTable: "Member",
                principalColumn: "PersNr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Member_memberPersNr",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "ParkingSpot");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.AlterColumn<string>(
                name: "memberPersNr",
                table: "Vehicle",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Member_memberPersNr",
                table: "Vehicle",
                column: "memberPersNr",
                principalTable: "Member",
                principalColumn: "PersNr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
