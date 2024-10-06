using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateReserevedItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalItemsPrice",
                table: "GoodReceiptNotes",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "GoodReceiptNoteItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "GoodReceiptNoteItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "GoodReceiptNoteItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "GoodReceiptNoteItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UsedQuantity",
                table: "GoodReceiptNoteItems",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "GoodIssueNoteItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "GoodIssueNoteItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "GoodIssueNoteItems",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "GoodIssueNoteItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReservedItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GoodReceiptNoteItemId = table.Column<int>(type: "integer", nullable: false),
                    UnitOfMeasureId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal", nullable: false),
                    IsActive = table.Column<bool>(type: "bool", nullable: false, defaultValue: true),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    GoodIssueNoteItemId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservedItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservedItem_GoodIssueNoteItems_GoodIssueNoteItemId",
                        column: x => x.GoodIssueNoteItemId,
                        principalTable: "GoodIssueNoteItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReservedItem_GoodReceiptNoteItems_GoodReceiptNoteItemId",
                        column: x => x.GoodReceiptNoteItemId,
                        principalTable: "GoodReceiptNoteItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservedItem_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "CanReturnGoodReceiptNote");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "CanRejectGoodReceiptNote");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "CanViewGoodReceiptNote");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "CanCreateGoodReceiptNote");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "CanAddAnnualProcurement");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "CanCreateDropDown");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "CanGetComment");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "CanAddComment");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 39, "CanViewProject" },
                    { 40, "CanChangeDashboard" },
                    { 41, "CanGetDropDown" },
                    { 42, "CanAddProject" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 39, 2 },
                    { 40, 2 },
                    { 41, 2 },
                    { 42, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceiptNoteItems_MaterialId",
                table: "GoodReceiptNoteItems",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceiptNoteItems_UnitOfMeasureId",
                table: "GoodReceiptNoteItems",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodIssueNoteItems_MaterialId",
                table: "GoodIssueNoteItems",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodIssueNoteItems_UnitOfMeasureId",
                table: "GoodIssueNoteItems",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedItem_GoodIssueNoteItemId",
                table: "ReservedItem",
                column: "GoodIssueNoteItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservedItem_GoodReceiptNoteItemId",
                table: "ReservedItem",
                column: "GoodReceiptNoteItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservedItem_UnitOfMeasureId",
                table: "ReservedItem",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodIssueNoteItems_Materials_MaterialId",
                table: "GoodIssueNoteItems",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodIssueNoteItems_UnitOfMeasures_UnitOfMeasureId",
                table: "GoodIssueNoteItems",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceiptNoteItems_Materials_MaterialId",
                table: "GoodReceiptNoteItems",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceiptNoteItems_UnitOfMeasures_UnitOfMeasureId",
                table: "GoodReceiptNoteItems",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodIssueNoteItems_Materials_MaterialId",
                table: "GoodIssueNoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodIssueNoteItems_UnitOfMeasures_UnitOfMeasureId",
                table: "GoodIssueNoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceiptNoteItems_Materials_MaterialId",
                table: "GoodReceiptNoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceiptNoteItems_UnitOfMeasures_UnitOfMeasureId",
                table: "GoodReceiptNoteItems");

            migrationBuilder.DropTable(
                name: "ReservedItem");

            migrationBuilder.DropIndex(
                name: "IX_GoodReceiptNoteItems_MaterialId",
                table: "GoodReceiptNoteItems");

            migrationBuilder.DropIndex(
                name: "IX_GoodReceiptNoteItems_UnitOfMeasureId",
                table: "GoodReceiptNoteItems");

            migrationBuilder.DropIndex(
                name: "IX_GoodIssueNoteItems_MaterialId",
                table: "GoodIssueNoteItems");

            migrationBuilder.DropIndex(
                name: "IX_GoodIssueNoteItems_UnitOfMeasureId",
                table: "GoodIssueNoteItems");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 39, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 40, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 41, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 42, 2 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DropColumn(
                name: "TotalItemsPrice",
                table: "GoodReceiptNotes");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "GoodReceiptNoteItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "GoodReceiptNoteItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "GoodReceiptNoteItems");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "GoodReceiptNoteItems");

            migrationBuilder.DropColumn(
                name: "UsedQuantity",
                table: "GoodReceiptNoteItems");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "GoodIssueNoteItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "GoodIssueNoteItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "GoodIssueNoteItems");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "GoodIssueNoteItems");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                column: "Name",
                value: "CanChangeDashboard");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                column: "Name",
                value: "CanViewProject");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "CanAddProject");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "CanAddAnnualProcurement");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "CanAddComment");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                column: "Name",
                value: "CanGetComment");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                column: "Name",
                value: "CanCreateDropDown");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                column: "Name",
                value: "CanGetDropDown");
        }
    }
}
