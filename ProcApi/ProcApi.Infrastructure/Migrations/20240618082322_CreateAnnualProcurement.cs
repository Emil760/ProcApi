using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAnnualProcurement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceId",
                table: "InvoiceDocumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocumentItems_PurchaseRequestItems_PurchaseRequestIt~",
                table: "InvoiceDocumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocumentItems_UnitOfMeasures_UnitOfMeasureId",
                table: "InvoiceDocumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocuments_Documents_DocumentId",
                table: "InvoiceDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocuments_Suppliers_SupplierId",
                table: "InvoiceDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceDocuments",
                table: "InvoiceDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceDocumentItems",
                table: "InvoiceDocumentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Configurations",
                table: "Configurations");

            migrationBuilder.RenameTable(
                name: "InvoiceDocuments",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "InvoiceDocumentItems",
                newName: "InvoiceItems");

            migrationBuilder.RenameTable(
                name: "Configurations",
                newName: "FeatureConfiguration");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDocuments_SupplierId",
                table: "Invoices",
                newName: "IX_Invoices_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDocumentItems_UnitOfMeasureId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDocumentItems_PurchaseRequestItemId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_PurchaseRequestItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDocumentItems_InvoiceId",
                table: "InvoiceItems",
                newName: "IX_InvoiceItems_InvoiceId");

            migrationBuilder.AddColumn<int>(
                name: "DashboardId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Projects",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "Materials",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConfigurationType",
                table: "FeatureConfiguration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "FeatureConfiguration",
                type: "varchar",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceItems",
                table: "InvoiceItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeatureConfiguration",
                table: "FeatureConfiguration",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AnnualProcurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false, defaultValue: new DateTime(2024, 6, 18, 12, 23, 22, 88, DateTimeKind.Local).AddTicks(614)),
                    LastUpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Version = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualProcurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dashboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GoodIssueNotes",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodIssueNotes", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_GoodIssueNotes_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodReceiptNotes",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodReceiptNotes", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_GoodReceiptNotes_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnualProcurementItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AnnualProcurementId = table.Column<int>(type: "integer", nullable: false),
                    MaterialId = table.Column<int>(type: "integer", nullable: false),
                    UnitOfMeasureId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualProcurementItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualProcurementItems_AnnualProcurements_AnnualProcurement~",
                        column: x => x.AnnualProcurementId,
                        principalTable: "AnnualProcurements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnualProcurementItems_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnnualProcurementItems_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodIssueNoteItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GoodIssueNoteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodIssueNoteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodIssueNoteItems_GoodIssueNotes_GoodIssueNoteId",
                        column: x => x.GoodIssueNoteId,
                        principalTable: "GoodIssueNotes",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GoodReceiptNoteItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GoodReceiptNoteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodReceiptNoteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoodReceiptNoteItems_GoodReceiptNotes_GoodReceiptNoteId",
                        column: x => x.GoodReceiptNoteId,
                        principalTable: "GoodReceiptNotes",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 30, "CanChangeDashboard" },
                    { 31, "CanViewProject" },
                    { 32, "CanAddProject" },
                    { 33, "CanAddAnnualProcurement" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 30, 2 },
                    { 31, 2 },
                    { 32, 2 },
                    { 33, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DashboardId",
                table: "Users",
                column: "DashboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_UnitOfMeasureId",
                table: "Materials",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualProcurementItems_AnnualProcurementId",
                table: "AnnualProcurementItems",
                column: "AnnualProcurementId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualProcurementItems_MaterialId",
                table: "AnnualProcurementItems",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnualProcurementItems_UnitOfMeasureId",
                table: "AnnualProcurementItems",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodIssueNoteItems_GoodIssueNoteId",
                table: "GoodIssueNoteItems",
                column: "GoodIssueNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_GoodReceiptNoteItems_GoodReceiptNoteId",
                table: "GoodReceiptNoteItems",
                column: "GoodReceiptNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_PurchaseRequestItems_PurchaseRequestItemId",
                table: "InvoiceItems",
                column: "PurchaseRequestItemId",
                principalTable: "PurchaseRequestItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_UnitOfMeasures_UnitOfMeasureId",
                table: "InvoiceItems",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Documents_DocumentId",
                table: "Invoices",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Suppliers_SupplierId",
                table: "Invoices",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_UnitOfMeasures_UnitOfMeasureId",
                table: "Materials",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Dashboards_DashboardId",
                table: "Users",
                column: "DashboardId",
                principalTable: "Dashboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_PurchaseRequestItems_PurchaseRequestItemId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_UnitOfMeasures_UnitOfMeasureId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Documents_DocumentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Suppliers_SupplierId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_UnitOfMeasures_UnitOfMeasureId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Dashboards_DashboardId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AnnualProcurementItems");

            migrationBuilder.DropTable(
                name: "Dashboards");

            migrationBuilder.DropTable(
                name: "GoodIssueNoteItems");

            migrationBuilder.DropTable(
                name: "GoodReceiptNoteItems");

            migrationBuilder.DropTable(
                name: "AnnualProcurements");

            migrationBuilder.DropTable(
                name: "GoodIssueNotes");

            migrationBuilder.DropTable(
                name: "GoodReceiptNotes");

            migrationBuilder.DropIndex(
                name: "IX_Users_DashboardId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Materials_UnitOfMeasureId",
                table: "Materials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceItems",
                table: "InvoiceItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeatureConfiguration",
                table: "FeatureConfiguration");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 30, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 31, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 32, 2 });

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 33, 2 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DropColumn(
                name: "DashboardId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "ConfigurationType",
                table: "FeatureConfiguration");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "FeatureConfiguration");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "InvoiceDocuments");

            migrationBuilder.RenameTable(
                name: "InvoiceItems",
                newName: "InvoiceDocumentItems");

            migrationBuilder.RenameTable(
                name: "FeatureConfiguration",
                newName: "Configurations");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_SupplierId",
                table: "InvoiceDocuments",
                newName: "IX_InvoiceDocuments_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_UnitOfMeasureId",
                table: "InvoiceDocumentItems",
                newName: "IX_InvoiceDocumentItems_UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_PurchaseRequestItemId",
                table: "InvoiceDocumentItems",
                newName: "IX_InvoiceDocumentItems_PurchaseRequestItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceDocumentItems",
                newName: "IX_InvoiceDocumentItems_InvoiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceDocuments",
                table: "InvoiceDocuments",
                column: "DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceDocumentItems",
                table: "InvoiceDocumentItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configurations",
                table: "Configurations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceId",
                table: "InvoiceDocumentItems",
                column: "InvoiceId",
                principalTable: "InvoiceDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocumentItems_PurchaseRequestItems_PurchaseRequestIt~",
                table: "InvoiceDocumentItems",
                column: "PurchaseRequestItemId",
                principalTable: "PurchaseRequestItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocumentItems_UnitOfMeasures_UnitOfMeasureId",
                table: "InvoiceDocumentItems",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocuments_Documents_DocumentId",
                table: "InvoiceDocuments",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocuments_Suppliers_SupplierId",
                table: "InvoiceDocuments",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
