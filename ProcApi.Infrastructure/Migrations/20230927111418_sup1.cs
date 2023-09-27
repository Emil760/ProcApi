using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class sup1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_InvoiceDocuments_DocumentId",
                table: "InvoiceDocuments");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalItemsPrice",
                table: "PurchaseRequestDocuments",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ItemStatusId",
                table: "PurchaseRequestDocumentItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "InvoiceDocuments",
                type: "varchar",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "InvoiceDocuments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalItemsPrice",
                table: "InvoiceDocuments",
                type: "decimal",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "InvoiceDocumentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceDocumentId = table.Column<int>(type: "integer", nullable: false),
                    PurchaseRequestDocumentItemId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDocumentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceDocumentId",
                        column: x => x.InvoiceDocumentId,
                        principalTable: "InvoiceDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDocumentItems_PurchaseRequestDocumentItems_PurchaseR~",
                        column: x => x.PurchaseRequestDocumentItemId,
                        principalTable: "PurchaseRequestDocumentItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Mail = table.Column<string>(type: "varchar", maxLength: 150, nullable: false),
                    TaxId = table.Column<string>(type: "char(10)", fixedLength: true, maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDocuments_DocumentId",
                table: "InvoiceDocuments",
                column: "DocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDocuments_SupplierId",
                table: "InvoiceDocuments",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDocumentItems_InvoiceDocumentId",
                table: "InvoiceDocumentItems",
                column: "InvoiceDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDocumentItems_PurchaseRequestDocumentItemId",
                table: "InvoiceDocumentItems",
                column: "PurchaseRequestDocumentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_Name",
                table: "Suppliers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_TaxId",
                table: "Suppliers",
                column: "TaxId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocuments_Suppliers_SupplierId",
                table: "InvoiceDocuments",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocuments_Suppliers_SupplierId",
                table: "InvoiceDocuments");

            migrationBuilder.DropTable(
                name: "InvoiceDocumentItems");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDocuments_DocumentId",
                table: "InvoiceDocuments");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDocuments_SupplierId",
                table: "InvoiceDocuments");

            migrationBuilder.DropColumn(
                name: "TotalItemsPrice",
                table: "PurchaseRequestDocuments");

            migrationBuilder.DropColumn(
                name: "ItemStatusId",
                table: "PurchaseRequestDocumentItems");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "InvoiceDocuments");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "InvoiceDocuments");

            migrationBuilder.DropColumn(
                name: "TotalItemsPrice",
                table: "InvoiceDocuments");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDocuments_DocumentId",
                table: "InvoiceDocuments",
                column: "DocumentId");
        }
    }
}
