using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Infrastructure.Migrations.Helpers;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.CreateGetUnusedPurchaseRequestItemsCountV1(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.DropGetUnusedPurchaseRequestItemsCountV1(migrationBuilder);
        }
    }
}
