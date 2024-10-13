using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrder1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Section",
                table: "DocumentNumberSections",
                newName: "Order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DocumentNumberPatterns",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 13, 0, 23, 39, 275, DateTimeKind.Local).AddTicks(7283),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2024, 10, 12, 20, 48, 44, 127, DateTimeKind.Local).AddTicks(6393));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "DocumentNumberSections",
                newName: "Section");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DocumentNumberPatterns",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 12, 20, 48, 44, 127, DateTimeKind.Local).AddTicks(6393),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2024, 10, 13, 0, 23, 39, 275, DateTimeKind.Local).AddTicks(7283));
        }
    }
}
