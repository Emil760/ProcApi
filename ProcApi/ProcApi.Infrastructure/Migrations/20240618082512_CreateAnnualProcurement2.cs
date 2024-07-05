using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAnnualProcurement2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnitOfMeasureId",
                table: "Materials",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AnnualProcurements",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 12, 25, 11, 881, DateTimeKind.Local).AddTicks(3692),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 6, 18, 12, 23, 22, 88, DateTimeKind.Local).AddTicks(614));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnitOfMeasureId",
                table: "Materials",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AnnualProcurements",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 12, 23, 22, 88, DateTimeKind.Local).AddTicks(614),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 6, 18, 12, 25, 11, 881, DateTimeKind.Local).AddTicks(3692));
        }
    }
}
