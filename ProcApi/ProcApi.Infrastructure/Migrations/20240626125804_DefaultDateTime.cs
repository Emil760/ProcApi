using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DefaultDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "timestamp",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValue: new DateTime(2024, 6, 26, 16, 38, 55, 335, DateTimeKind.Local).AddTicks(5610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AnnualProcurements",
                type: "date",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 6, 26, 16, 38, 55, 333, DateTimeKind.Local).AddTicks(3218));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Comments",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 16, 38, 55, 335, DateTimeKind.Local).AddTicks(5610),
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AnnualProcurements",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 26, 16, 38, 55, 333, DateTimeKind.Local).AddTicks(3218),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");
        }
    }
}
