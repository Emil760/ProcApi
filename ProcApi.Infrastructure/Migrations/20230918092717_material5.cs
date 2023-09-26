using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class material5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "ChatMessages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 18, 13, 27, 17, 751, DateTimeKind.Local).AddTicks(48),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 9, 18, 13, 26, 57, 716, DateTimeKind.Local).AddTicks(7061));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "ChatMessages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 18, 13, 26, 57, 716, DateTimeKind.Local).AddTicks(7061),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 9, 18, 13, 27, 17, 751, DateTimeKind.Local).AddTicks(48));
        }
    }
}
