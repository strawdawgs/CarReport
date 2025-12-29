using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingEstimatedCostToServiceTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstimatedCost",
                table: "ServiceTypes",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedCost",
                table: "ServiceTypes");
        }
    }
}
