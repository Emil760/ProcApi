using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcApi.Data.ProcDatabase.Migrations
{
    /// <inheritdoc />
    public partial class chat1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Users_FromId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Users_ToId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "ToId",
                table: "ChatMessages",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "FromId",
                table: "ChatMessages",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_ToId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_FromId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_GroupId");

            migrationBuilder.AddColumn<string>(
                name: "SendedMessage",
                table: "ChatMessages",
                type: "json",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactTypeId = table.Column<int>(type: "int", nullable: false),
                    ContactType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupId",
                table: "GroupUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_UserId",
                table: "GroupUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Groups_GroupId",
                table: "ChatMessages",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Users_SenderId",
                table: "ChatMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Groups_GroupId",
                table: "ChatMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_Users_SenderId",
                table: "ChatMessages");

            migrationBuilder.DropTable(
                name: "GroupUsers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropColumn(
                name: "SendedMessage",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "ChatMessages",
                newName: "ToId");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "ChatMessages",
                newName: "FromId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_ToId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_GroupId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_FromId");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ChatMessages",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Users_FromId",
                table: "ChatMessages",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_Users_ToId",
                table: "ChatMessages",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
