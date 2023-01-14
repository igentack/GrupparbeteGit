using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitGruppen.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReversedCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpot_Vehicle_vehicleLicensePlate",
                table: "ParkingSpot");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpot_vehicleLicensePlate",
                table: "ParkingSpot");

            migrationBuilder.DropColumn(
                name: "vehicleLicensePlate",
                table: "ParkingSpot");

            migrationBuilder.AddColumn<int>(
                name: "ParkingSpotId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Member",
                table: "Receipt",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemberPersNr",
                table: "Receipt",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ParkingSpotId",
                table: "Vehicle",
                column: "ParkingSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_MemberPersNr",
                table: "Receipt",
                column: "MemberPersNr");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Member_MemberPersNr",
                table: "Receipt",
                column: "MemberPersNr",
                principalTable: "Member",
                principalColumn: "PersNr");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_ParkingSpot_ParkingSpotId",
                table: "Vehicle",
                column: "ParkingSpotId",
                principalTable: "ParkingSpot",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Member_MemberPersNr",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_ParkingSpot_ParkingSpotId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ParkingSpotId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Receipt_MemberPersNr",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "ParkingSpotId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Member",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "MemberPersNr",
                table: "Receipt");

            migrationBuilder.AddColumn<string>(
                name: "vehicleLicensePlate",
                table: "ParkingSpot",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpot_vehicleLicensePlate",
                table: "ParkingSpot",
                column: "vehicleLicensePlate");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpot_Vehicle_vehicleLicensePlate",
                table: "ParkingSpot",
                column: "vehicleLicensePlate",
                principalTable: "Vehicle",
                principalColumn: "LicensePlate");
        }
    }
}
