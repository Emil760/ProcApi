using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Infrastructure.Migrations.Helpers;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GetPurchaseRequestUnusedCountV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.DropGetUnusedPurchaseRequestItemsCountV1(migrationBuilder);
            FunctionsMigrationHelper.CreateGetUnusedPurchaseRequestItemsCountV2(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.DropGetUnusedPurchaseRequestItemsCountV2(migrationBuilder);
            FunctionsMigrationHelper.CreateGetUnusedPurchaseRequestItemsCountV1(migrationBuilder);
        }
    }
}
