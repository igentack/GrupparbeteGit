using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitGruppen.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixcase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Vehicle_vehicleLicensePlate",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Member_memberPersNr",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleType_vehicleTypeId",
                table: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "vehicleTypeId",
                table: "Vehicle",
                newName: "VehicleTypeId");

            migrationBuilder.RenameColumn(
                name: "memberPersNr",
                table: "Vehicle",
                newName: "MemberPersNr");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_vehicleTypeId",
                table: "Vehicle",
                newName: "IX_Vehicle_VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_memberPersNr",
                table: "Vehicle",
                newName: "IX_Vehicle_MemberPersNr");

            migrationBuilder.RenameColumn(
                name: "vehicleLicensePlate",
                table: "Receipt",
                newName: "VehicleLicensePlate");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_vehicleLicensePlate",
                table: "Receipt",
                newName: "IX_Receipt_VehicleLicensePlate");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Vehicle_VehicleLicensePlate",
                table: "Receipt",
                column: "VehicleLicensePlate",
                principalTable: "Vehicle",
                principalColumn: "LicensePlate",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Member_MemberPersNr",
                table: "Vehicle",
                column: "MemberPersNr",
                principalTable: "Member",
                principalColumn: "PersNr");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Vehicle_VehicleLicensePlate",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Member_MemberPersNr",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "Vehicle",
                newName: "vehicleTypeId");

            migrationBuilder.RenameColumn(
                name: "MemberPersNr",
                table: "Vehicle",
                newName: "memberPersNr");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                newName: "IX_Vehicle_vehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_MemberPersNr",
                table: "Vehicle",
                newName: "IX_Vehicle_memberPersNr");

            migrationBuilder.RenameColumn(
                name: "VehicleLicensePlate",
                table: "Receipt",
                newName: "vehicleLicensePlate");

            migrationBuilder.RenameIndex(
                name: "IX_Receipt_VehicleLicensePlate",
                table: "Receipt",
                newName: "IX_Receipt_vehicleLicensePlate");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Vehicle_vehicleLicensePlate",
                table: "Receipt",
                column: "vehicleLicensePlate",
                principalTable: "Vehicle",
                principalColumn: "LicensePlate",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Member_memberPersNr",
                table: "Vehicle",
                column: "memberPersNr",
                principalTable: "Member",
                principalColumn: "PersNr");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleType_vehicleTypeId",
                table: "Vehicle",
                column: "vehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
