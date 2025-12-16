using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkAccess.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRecords_Vehicles_VehicleId",
                table: "ServiceRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TireRecords_Vehicles_VehicleId",
                table: "TireRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TireRecords",
                table: "TireRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceRecords",
                table: "ServiceRecords");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "TireRecords",
                newName: "TireRecord");

            migrationBuilder.RenameTable(
                name: "ServiceRecords",
                newName: "ServiceRecord");

            migrationBuilder.RenameIndex(
                name: "IX_TireRecords_VehicleId",
                table: "TireRecord",
                newName: "IX_TireRecord_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceRecords_VehicleId",
                table: "ServiceRecord",
                newName: "IX_ServiceRecord_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TireRecord",
                table: "TireRecord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceRecord",
                table: "ServiceRecord",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRecord_Vehicle_VehicleId",
                table: "ServiceRecord",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TireRecord_Vehicle_VehicleId",
                table: "TireRecord",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRecord_Vehicle_VehicleId",
                table: "ServiceRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_TireRecord_Vehicle_VehicleId",
                table: "TireRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TireRecord",
                table: "TireRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceRecord",
                table: "ServiceRecord");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "TireRecord",
                newName: "TireRecords");

            migrationBuilder.RenameTable(
                name: "ServiceRecord",
                newName: "ServiceRecords");

            migrationBuilder.RenameIndex(
                name: "IX_TireRecord_VehicleId",
                table: "TireRecords",
                newName: "IX_TireRecords_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceRecord_VehicleId",
                table: "ServiceRecords",
                newName: "IX_ServiceRecords_VehicleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TireRecords",
                table: "TireRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceRecords",
                table: "ServiceRecords",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRecords_Vehicles_VehicleId",
                table: "ServiceRecords",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TireRecords_Vehicles_VehicleId",
                table: "TireRecords",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
