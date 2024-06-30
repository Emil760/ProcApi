using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnitOfMeasureInMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_UnitOfMeasures_UnitOfMeasureId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_UnitOfMeasureId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "Materials");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AnnualProcurements",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 19, 22, 18, 46, 873, DateTimeKind.Local).AddTicks(4781),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 6, 18, 12, 25, 11, 881, DateTimeKind.Local).AddTicks(3692));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "Materials",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "AnnualProcurements",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 18, 12, 25, 11, 881, DateTimeKind.Local).AddTicks(3692),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldDefaultValue: new DateTime(2024, 6, 19, 22, 18, 46, 873, DateTimeKind.Local).AddTicks(4781));

            migrationBuilder.CreateIndex(
                name: "IX_Materials_UnitOfMeasureId",
                table: "Materials",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_UnitOfMeasures_UnitOfMeasureId",
                table: "Materials",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
