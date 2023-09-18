using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Data.ProcDatabase.Migrations
{
    /// <inheritdoc />
    public partial class material6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "ChatMessages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "CURRENT_DATE",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 9, 18, 13, 27, 17, 751, DateTimeKind.Local).AddTicks(48));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "ChatMessages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 18, 13, 27, 17, 751, DateTimeKind.Local).AddTicks(48),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "CURRENT_DATE");
        }
    }
}
