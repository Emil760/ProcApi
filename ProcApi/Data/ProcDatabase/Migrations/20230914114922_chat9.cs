using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Data.ProcDatabase.Models;

#nullable disable

namespace ProcApi.Data.ProcDatabase.Migrations
{
    /// <inheritdoc />
    public partial class chat9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "ChatMessages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 14, 15, 49, 21, 904, DateTimeKind.Local).AddTicks(4943),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 9, 14, 15, 47, 9, 152, DateTimeKind.Local).AddTicks(8329));

            migrationBuilder.AlterColumn<IEnumerable<ReceivedInfo>>(
                name: "ReceivedInfos",
                table: "ChatMessages",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(IEnumerable<ReceivedInfo>),
                oldType: "jsonb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SendTime",
                table: "ChatMessages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 14, 15, 47, 9, 152, DateTimeKind.Local).AddTicks(8329),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValue: new DateTime(2023, 9, 14, 15, 49, 21, 904, DateTimeKind.Local).AddTicks(4943));

            migrationBuilder.AlterColumn<IEnumerable<ReceivedInfo>>(
                name: "ReceivedInfos",
                table: "ChatMessages",
                type: "jsonb",
                nullable: false,
                oldClrType: typeof(IEnumerable<ReceivedInfo>),
                oldType: "jsonb",
                oldNullable: true);
        }
    }
}
