using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class invoice5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                table: "InvoiceDocumentItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDocumentItems_UnitOfMeasureId",
                table: "InvoiceDocumentItems",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocumentItems_UnitOfMeasures_UnitOfMeasureId",
                table: "InvoiceDocumentItems",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocumentItems_UnitOfMeasures_UnitOfMeasureId",
                table: "InvoiceDocumentItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDocumentItems_UnitOfMeasureId",
                table: "InvoiceDocumentItems");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                table: "InvoiceDocumentItems");
        }
    }
}
