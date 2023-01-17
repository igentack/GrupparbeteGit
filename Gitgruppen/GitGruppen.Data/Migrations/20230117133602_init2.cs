using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GitGruppen.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_ParkingSpot_ParkingSpotId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ParkingSpotId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingSpotId",
                table: "Vehicle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ParkingSpotId",
                table: "Vehicle",
                column: "ParkingSpotId",
                unique: true,
                filter: "[ParkingSpotId] IS NOT NULL");

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
                name: "FK_Vehicle_ParkingSpot_ParkingSpotId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_ParkingSpotId",
                table: "Vehicle");

            migrationBuilder.AlterColumn<int>(
                name: "ParkingSpotId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ParkingSpotId",
                table: "Vehicle",
                column: "ParkingSpotId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_ParkingSpot_ParkingSpotId",
                table: "Vehicle",
                column: "ParkingSpotId",
                principalTable: "ParkingSpot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
