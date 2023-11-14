using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Infrastructure.Migrations.Helpers;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateGetUnusedPurchaseRequestItemsByIdsV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.DropGetUnusedPurchaseRequestItemsByIdsV1(migrationBuilder);
            FunctionsMigrationHelper.CreateGetUnusedPurchaseRequestItemsByIdsV2(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.DropGetUnusedPurchaseRequestItemsByIdsV2(migrationBuilder);
            FunctionsMigrationHelper.CreateGetUnusedPurchaseRequestItemsByIdsV1(migrationBuilder);
        }
    }
}
