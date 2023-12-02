using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceDocumentId",
                table: "InvoiceDocumentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceDocuments",
                table: "InvoiceDocuments");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDocuments_DocumentId",
                table: "InvoiceDocuments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "InvoiceDocuments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceDocuments",
                table: "InvoiceDocuments",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceDocumentId",
                table: "InvoiceDocumentItems",
                column: "InvoiceDocumentId",
                principalTable: "InvoiceDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceDocumentId",
                table: "InvoiceDocumentItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceDocuments",
                table: "InvoiceDocuments");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "InvoiceDocuments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceDocuments",
                table: "InvoiceDocuments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDocuments_DocumentId",
                table: "InvoiceDocuments",
                column: "DocumentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocumentItems_InvoiceDocuments_InvoiceDocumentId",
                table: "InvoiceDocumentItems",
                column: "InvoiceDocumentId",
                principalTable: "InvoiceDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
