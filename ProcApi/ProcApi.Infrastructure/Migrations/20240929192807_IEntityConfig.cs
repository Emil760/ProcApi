using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IEntityConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodIssueNotes_Documents_DocumentId",
                table: "GoodIssueNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceiptNotes_Documents_DocumentId",
                table: "GoodReceiptNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Chats_ChatId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_ChatUsers_ChatUserId",
                table: "GroupUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Documents_DocumentId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Documents_DocumentId",
                table: "PurchaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedItem_GoodIssueNoteItems_GoodIssueNoteItemId",
                table: "ReservedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedItem_GoodReceiptNoteItems_GoodReceiptNoteItemId",
                table: "ReservedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedItem_UnitOfMeasures_UnitOfMeasureId",
                table: "ReservedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPassword_Users_UserId",
                table: "UserPassword");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_Users_UserId",
                table: "UserSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservedItem",
                table: "ReservedItem");

            migrationBuilder.RenameTable(
                name: "ReservedItem",
                newName: "ReservedItems");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserSettings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserPassword",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "PurchaseRequests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Invoices",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ChatUserId",
                table: "GroupUsers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "Groups",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "GoodReceiptNotes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "GoodIssueNotes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ReservedItem_UnitOfMeasureId",
                table: "ReservedItems",
                newName: "IX_ReservedItems_UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservedItem_GoodReceiptNoteItemId",
                table: "ReservedItems",
                newName: "IX_ReservedItems_GoodReceiptNoteItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservedItem_GoodIssueNoteItemId",
                table: "ReservedItems",
                newName: "IX_ReservedItems_GoodIssueNoteItemId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserRoles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GoodReceiptNoteNumber",
                table: "ReservedItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservedItems",
                table: "ReservedItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodIssueNotes_Documents_Id",
                table: "GoodIssueNotes",
                column: "Id",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceiptNotes_Documents_Id",
                table: "GoodReceiptNotes",
                column: "Id",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Chats_Id",
                table: "Groups",
                column: "Id",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_ChatUsers_Id",
                table: "GroupUsers",
                column: "Id",
                principalTable: "ChatUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Documents_Id",
                table: "Invoices",
                column: "Id",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseRequests_Documents_Id",
                table: "PurchaseRequests",
                column: "Id",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedItems_GoodIssueNoteItems_GoodIssueNoteItemId",
                table: "ReservedItems",
                column: "GoodIssueNoteItemId",
                principalTable: "GoodIssueNoteItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedItems_GoodReceiptNoteItems_GoodReceiptNoteItemId",
                table: "ReservedItems",
                column: "GoodReceiptNoteItemId",
                principalTable: "GoodReceiptNoteItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedItems_UnitOfMeasures_UnitOfMeasureId",
                table: "ReservedItems",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPassword_Users_Id",
                table: "UserPassword",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_Users_Id",
                table: "UserSettings",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoodIssueNotes_Documents_Id",
                table: "GoodIssueNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_GoodReceiptNotes_Documents_Id",
                table: "GoodReceiptNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Chats_Id",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupUsers_ChatUsers_Id",
                table: "GroupUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Documents_Id",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseRequests_Documents_Id",
                table: "PurchaseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedItems_GoodIssueNoteItems_GoodIssueNoteItemId",
                table: "ReservedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedItems_GoodReceiptNoteItems_GoodReceiptNoteItemId",
                table: "ReservedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservedItems_UnitOfMeasures_UnitOfMeasureId",
                table: "ReservedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPassword_Users_Id",
                table: "UserPassword");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_Users_Id",
                table: "UserSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservedItems",
                table: "ReservedItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "GoodReceiptNoteNumber",
                table: "ReservedItems");

            migrationBuilder.RenameTable(
                name: "ReservedItems",
                newName: "ReservedItem");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserSettings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserPassword",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PurchaseRequests",
                newName: "DocumentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Invoices",
                newName: "DocumentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GroupUsers",
                newName: "ChatUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Groups",
                newName: "ChatId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GoodReceiptNotes",
                newName: "DocumentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GoodIssueNotes",
                newName: "DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservedItems_UnitOfMeasureId",
                table: "ReservedItem",
                newName: "IX_ReservedItem_UnitOfMeasureId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservedItems_GoodReceiptNoteItemId",
                table: "ReservedItem",
                newName: "IX_ReservedItem_GoodReceiptNoteItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservedItems_GoodIssueNoteItemId",
                table: "ReservedItem",
                newName: "IX_ReservedItem_GoodIssueNoteItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservedItem",
                table: "ReservedItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoodIssueNotes_Documents_DocumentId",
                table: "GoodIssueNotes",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoodReceiptNotes_Documents_DocumentId",
                table: "GoodReceiptNotes",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Chats_ChatId",
                table: "Groups",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupUsers_ChatUsers_ChatUserId",
                table: "GroupUsers",
                column: "ChatUserId",
                principalTable: "ChatUsers",
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
                name: "FK_PurchaseRequests_Documents_DocumentId",
                table: "PurchaseRequests",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedItem_GoodIssueNoteItems_GoodIssueNoteItemId",
                table: "ReservedItem",
                column: "GoodIssueNoteItemId",
                principalTable: "GoodIssueNoteItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedItem_GoodReceiptNoteItems_GoodReceiptNoteItemId",
                table: "ReservedItem",
                column: "GoodReceiptNoteItemId",
                principalTable: "GoodReceiptNoteItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservedItem_UnitOfMeasures_UnitOfMeasureId",
                table: "ReservedItem",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPassword_Users_UserId",
                table: "UserPassword",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_Users_UserId",
                table: "UserSettings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
