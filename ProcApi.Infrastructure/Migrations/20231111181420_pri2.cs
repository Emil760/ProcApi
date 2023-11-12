using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class pri2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocumentItems_PurchaseRequestDocumentItems_PurchaseR~",
                table: "InvoiceDocumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDocumentItems_Materials_MaterialId",
                table: "PurchaseRequestDocumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDocumentItems_PurchaseRequestDocuments_Purch~",
                table: "PurchaseRequestDocumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDocumentItems_UnitOfMeasures_UnitOfMeasureId",
                table: "PurchaseRequestDocumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDocuments_Departments_RequestedForDepartment~",
                table: "PurchaseRequestDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDocuments_Documents_DocumentId",
                table: "PurchaseRequestDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestDocuments_Projects_ProjectId",
                table: "PurchaseRequestDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseRequestDocuments",
                table: "PurchaseRequestDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseRequestDocumentItems",
                table: "PurchaseRequestDocumentItems");

            migrationBuilder.RenameTable(
                name: "PurchaseRequestDocuments",
                newName: "PurchaseRequests");

            migrationBuilder.RenameTable(
                name: "PurchaseRequestDocumentItems",
                newName: "PurchaseRequestItems");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDocuments_RequestedForDepartmentId",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_RequestedForDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDocuments_ProjectId",
                table: "PurchaseRequests",
                newName: "IX_PurchaseRequests_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDocumentItems_UnitOfMeasureId",
                table: "PurchaseRequestItems",
                newName: "IX_PurchaseRequestItems_UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDocumentItems_PurchaseRequestId",
                table: "PurchaseRequestItems",
                newName: "IX_PurchaseRequestItems_PurchaseRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestDocumentItems_MaterialId",
                table: "PurchaseRequestItems",
                newName: "IX_PurchaseRequestItems_MaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseRequests",
                table: "PurchaseRequests",
                column: "DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseRequestItems",
                table: "PurchaseRequestItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 17, "CanCreateDepartment" },
                    { 18, "CanAssignUserDepartment" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocumentItems_PurchaseRequestItems_PurchaseRequestIt~",
                table: "InvoiceDocumentItems",
                column: "PurchaseRequestItemId",
                principalTable: "PurchaseRequestItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestItems_Materials_MaterialId",
                table: "PurchaseRequestItems",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestItems_PurchaseRequests_PurchaseRequestId",
                table: "PurchaseRequestItems",
                column: "PurchaseRequestId",
                principalTable: "PurchaseRequests",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestItems_UnitOfMeasures_UnitOfMeasureId",
                table: "PurchaseRequestItems",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Departments_RequestedForDepartmentId",
                table: "PurchaseRequests",
                column: "RequestedForDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Documents_DocumentId",
                table: "PurchaseRequests",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Projects_ProjectId",
                table: "PurchaseRequests",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDocumentItems_PurchaseRequestItems_PurchaseRequestIt~",
                table: "InvoiceDocumentItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestItems_Materials_MaterialId",
                table: "PurchaseRequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestItems_PurchaseRequests_PurchaseRequestId",
                table: "PurchaseRequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequestItems_UnitOfMeasures_UnitOfMeasureId",
                table: "PurchaseRequestItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Departments_RequestedForDepartmentId",
                table: "PurchaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Documents_DocumentId",
                table: "PurchaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Projects_ProjectId",
                table: "PurchaseRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseRequests",
                table: "PurchaseRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseRequestItems",
                table: "PurchaseRequestItems");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.RenameTable(
                name: "PurchaseRequests",
                newName: "PurchaseRequestDocuments");

            migrationBuilder.RenameTable(
                name: "PurchaseRequestItems",
                newName: "PurchaseRequestDocumentItems");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_RequestedForDepartmentId",
                table: "PurchaseRequestDocuments",
                newName: "IX_PurchaseRequestDocuments_RequestedForDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequests_ProjectId",
                table: "PurchaseRequestDocuments",
                newName: "IX_PurchaseRequestDocuments_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestItems_UnitOfMeasureId",
                table: "PurchaseRequestDocumentItems",
                newName: "IX_PurchaseRequestDocumentItems_UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestItems_PurchaseRequestId",
                table: "PurchaseRequestDocumentItems",
                newName: "IX_PurchaseRequestDocumentItems_PurchaseRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseRequestItems_MaterialId",
                table: "PurchaseRequestDocumentItems",
                newName: "IX_PurchaseRequestDocumentItems_MaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseRequestDocuments",
                table: "PurchaseRequestDocuments",
                column: "DocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseRequestDocumentItems",
                table: "PurchaseRequestDocumentItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDocumentItems_PurchaseRequestDocumentItems_PurchaseR~",
                table: "InvoiceDocumentItems",
                column: "PurchaseRequestItemId",
                principalTable: "PurchaseRequestDocumentItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDocumentItems_Materials_MaterialId",
                table: "PurchaseRequestDocumentItems",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDocumentItems_PurchaseRequestDocuments_Purch~",
                table: "PurchaseRequestDocumentItems",
                column: "PurchaseRequestId",
                principalTable: "PurchaseRequestDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDocumentItems_UnitOfMeasures_UnitOfMeasureId",
                table: "PurchaseRequestDocumentItems",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDocuments_Departments_RequestedForDepartment~",
                table: "PurchaseRequestDocuments",
                column: "RequestedForDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDocuments_Documents_DocumentId",
                table: "PurchaseRequestDocuments",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequestDocuments_Projects_ProjectId",
                table: "PurchaseRequestDocuments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
