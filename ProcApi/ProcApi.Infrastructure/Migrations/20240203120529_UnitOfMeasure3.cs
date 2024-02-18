using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnitOfMeasure3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UnitOfMeasures",
                type: "bool",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UnitOfMeasureConverters",
                type: "bool",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "CanBeDecimal",
                table: "UnitOfMeasureConverters",
                type: "bool",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UnitOfMeasures",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bool",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "UnitOfMeasureConverters",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bool",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "CanBeDecimal",
                table: "UnitOfMeasureConverters",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bool",
                oldDefaultValue: false);
        }
    }
}
