using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProcApi.Data.ProcDatabase.Models;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProcApi.Data.ProcDatabase.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChatType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 300, nullable: true),
                    IsEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false, defaultValue: 2)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 300, nullable: false, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Groups_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "varchar", maxLength: 300, nullable: true),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: true),
                    DocumentTypeId = table.Column<int>(type: "integer", nullable: false),
                    DocumentStatusId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsEditable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsMandatory = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlSets_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    PermissionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasureConverter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SourceUnitOfMeasureId = table.Column<int>(type: "integer", nullable: false),
                    TargetUnitOfMeasureId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Value = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasureConverter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureConverter_UnitOfMeasures_SourceUnitOfMeasureId",
                        column: x => x.SourceUnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UnitOfMeasureConverter_UnitOfMeasures_TargetUnitOfMeasureId",
                        column: x => x.TargetUnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApprovalFlowTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentTypeId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    IsInitial = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsCreator = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalFlowTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalFlowTemplates_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalFlowTemplates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChatId = table.Column<int>(type: "integer", nullable: false),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "varchar", maxLength: 2000, nullable: false),
                    ReceivedInfo = table.Column<ReceivedInfo>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delegations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromUserId = table.Column<int>(type: "integer", nullable: false),
                    ToUserId = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delegations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delegations_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Delegations_Users_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentTypeId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedById = table.Column<int>(type: "integer", nullable: false),
                    DocumentNumber = table.Column<string>(type: "varchar", maxLength: 30, nullable: true),
                    DocumentStatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserPassword",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Salt = table.Column<string>(type: "text", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPassword", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserPassword_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSettings",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSettings", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserSettings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ChatId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: true),
                    ChatRole = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatUsers_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUsers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseStrategies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ActiveStatusId = table.Column<int>(type: "integer", nullable: false),
                    AssignStatusId = table.Column<int>(type: "integer", nullable: false),
                    ActionTypeId = table.Column<int>(type: "integer", nullable: false),
                    ApprovalFlowTemplateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseStrategies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReleaseStrategies_ApprovalFlowTemplates_ApprovalFlowTemplat~",
                        column: x => x.ApprovalFlowTemplateId,
                        principalTable: "ApprovalFlowTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ActionPerformed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsPerformed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentActions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentActions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestDocuments",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "integer", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false, defaultValue: ""),
                    RequestedForDepartmentId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestDocuments", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDocuments_Departments_RequestedForDepartment~",
                        column: x => x.RequestedForDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDocuments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDocuments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequestDocumentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaseRequestDocumentId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UnitOfMeasureId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestDocumentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDocumentItems_PurchaseRequestDocuments_Purch~",
                        column: x => x.PurchaseRequestDocumentId,
                        principalTable: "PurchaseRequestDocuments",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestDocumentItems_UnitOfMeasures_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CanCreateUser" },
                    { 2, "CanDeleteUser" },
                    { 3, "CanEditUser" },
                    { 4, "CanActivateUser" },
                    { 5, "CanCreatePurchaseRequestDocument" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" },
                    { 3, "Requester" },
                    { 4, "Warehouse" },
                    { 5, "Coordinator" },
                    { 6, "Finance" },
                    { 7, "HeadDepartment" },
                    { 8, "ProcurementDirector" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 1 },
                    { 2, 2 },
                    { 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalFlowTemplates_RoleId",
                table: "ApprovalFlowTemplates",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalFlowTemplates_UserId",
                table: "ApprovalFlowTemplates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_ChatId",
                table: "ChatMessages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_SenderId",
                table: "ChatMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_ChatId",
                table: "ChatUsers",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_GroupId",
                table: "ChatUsers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_UserId",
                table: "ChatUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ControlSets_RoleId",
                table: "ControlSets",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Delegations_FromUserId",
                table: "Delegations",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Delegations_ToUserId",
                table: "Delegations",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentActions_DocumentId",
                table: "DocumentActions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentActions_RoleId",
                table: "DocumentActions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentActions_UserId",
                table: "DocumentActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CreatedById",
                table: "Documents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDocuments_DocumentId",
                table: "InvoiceDocuments",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDocumentItems_PurchaseRequestDocumentId",
                table: "PurchaseRequestDocumentItems",
                column: "PurchaseRequestDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDocumentItems_UnitOfMeasureId",
                table: "PurchaseRequestDocumentItems",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDocuments_ProjectId",
                table: "PurchaseRequestDocuments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestDocuments_RequestedForDepartmentId",
                table: "PurchaseRequestDocuments",
                column: "RequestedForDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReleaseStrategies_ApprovalFlowTemplateId",
                table: "ReleaseStrategies",
                column: "ApprovalFlowTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureConverter_SourceUnitOfMeasureId",
                table: "UnitOfMeasureConverter",
                column: "SourceUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitOfMeasureConverter_TargetUnitOfMeasureId",
                table: "UnitOfMeasureConverter",
                column: "TargetUnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ChatUsers");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "ControlSets");

            migrationBuilder.DropTable(
                name: "Delegations");

            migrationBuilder.DropTable(
                name: "DocumentActions");

            migrationBuilder.DropTable(
                name: "InvoiceDocuments");

            migrationBuilder.DropTable(
                name: "PurchaseRequestDocumentItems");

            migrationBuilder.DropTable(
                name: "ReleaseStrategies");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UnitOfMeasureConverter");

            migrationBuilder.DropTable(
                name: "UserPassword");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserSettings");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "PurchaseRequestDocuments");

            migrationBuilder.DropTable(
                name: "ApprovalFlowTemplates");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "UnitOfMeasures");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
