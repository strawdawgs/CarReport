using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovingNextDueMileageFromServiceRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextDueDate",
                table: "ServiceRecords");

            migrationBuilder.DropColumn(
                name: "NextDueMileage",
                table: "ServiceRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "NextDueDate",
                table: "ServiceRecords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextDueMileage",
                table: "ServiceRecords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
