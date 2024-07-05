using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnnualProcurementDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "AnnualProcurements",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AnnualProcurements",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 22, 24, 5, 911, DateTimeKind.Local).AddTicks(3626),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 6, 19, 22, 18, 46, 873, DateTimeKind.Local).AddTicks(4781));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDate",
                table: "AnnualProcurements",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AnnualProcurements",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 22, 18, 46, 873, DateTimeKind.Local).AddTicks(4781),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 6, 19, 22, 24, 5, 911, DateTimeKind.Local).AddTicks(3626));
        }
    }
}
