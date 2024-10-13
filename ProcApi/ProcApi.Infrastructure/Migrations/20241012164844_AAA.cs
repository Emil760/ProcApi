using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AAA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "DocumentNumberSections",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DocumentNumberPatterns",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 12, 20, 48, 44, 127, DateTimeKind.Local).AddTicks(6393),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2024, 10, 6, 22, 32, 34, 878, DateTimeKind.Local).AddTicks(7454));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "DocumentNumberSections");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "DocumentNumberPatterns",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 6, 22, 32, 34, 878, DateTimeKind.Local).AddTicks(7454),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2024, 10, 12, 20, 48, 44, 127, DateTimeKind.Local).AddTicks(6393));
        }
    }
}
