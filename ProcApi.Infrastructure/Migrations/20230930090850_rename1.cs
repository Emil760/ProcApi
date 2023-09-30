using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class rename1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceDocumentId",
                table: "InvoiceDocumentItems");

            migrationBuilder.RenameColumn(
                name: "PurchaseRequestDocumentId",
                table: "PurchaseRequestDocumentItems",
                newName: "PurchaseRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDocumentItems_PurchaseRequestDocumentId",
                table: "PurchaseRequestDocumentItems",
                newName: "IX_PurchaseRequestDocumentItems_PurchaseRequestId");

            migrationBuilder.RenameColumn(
                name: "PurchaseRequestDocumentItemId",
                table: "InvoiceDocumentItems",
                newName: "PurchaseRequestItemId");

            migrationBuilder.RenameColumn(
                name: "InvoiceDocumentId",
                table: "InvoiceDocumentItems",
                newName: "InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDocumentItems_PurchaseRequestDocumentItemId",
                table: "InvoiceDocumentItems",
                newName: "IX_InvoiceDocumentItems_PurchaseRequestItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDocumentItems_InvoiceDocumentId",
                table: "InvoiceDocumentItems",
                newName: "IX_InvoiceDocumentItems_InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceId",
                table: "InvoiceDocumentItems",
                column: "InvoiceId",
                principalTable: "InvoiceDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceId",
                table: "InvoiceDocumentItems");

            migrationBuilder.RenameColumn(
                name: "PurchaseRequestId",
                table: "PurchaseRequestDocumentItems",
                newName: "PurchaseRequestDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDocumentItems_PurchaseRequestId",
                table: "PurchaseRequestDocumentItems",
                newName: "IX_PurchaseRequestDocumentItems_PurchaseRequestDocumentId");

            migrationBuilder.RenameColumn(
                name: "PurchaseRequestItemId",
                table: "InvoiceDocumentItems",
                newName: "PurchaseRequestDocumentItemId");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "InvoiceDocumentItems",
                newName: "InvoiceDocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDocumentItems_PurchaseRequestItemId",
                table: "InvoiceDocumentItems",
                newName: "IX_InvoiceDocumentItems_PurchaseRequestDocumentItemId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceDocumentItems_InvoiceId",
                table: "InvoiceDocumentItems",
                newName: "IX_InvoiceDocumentItems_InvoiceDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceDocumentId",
                table: "InvoiceDocumentItems",
                column: "InvoiceDocumentId",
                principalTable: "InvoiceDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
