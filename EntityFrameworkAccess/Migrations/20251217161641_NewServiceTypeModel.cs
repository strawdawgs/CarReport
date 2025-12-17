using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewServiceTypeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecommendedInterval",
                table: "ServiceRecords");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "ServiceRecords");

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "ServiceRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RecommendedIntervalInMiles = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RecommendedIntervalInYears = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRecords_ServiceTypeId",
                table: "ServiceRecords",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRecords_ServiceTypes_ServiceTypeId",
                table: "ServiceRecords",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRecords_ServiceTypes_ServiceTypeId",
                table: "ServiceRecords");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ServiceRecords_ServiceTypeId",
                table: "ServiceRecords");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "ServiceRecords");

            migrationBuilder.AddColumn<string>(
                name: "RecommendedInterval",
                table: "ServiceRecords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "ServiceRecords",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
