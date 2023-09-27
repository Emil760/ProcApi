using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Infrastructure.Functions;

#nullable disable

namespace ProcApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.CreateGetPurchaseRequestUnusedItemsCountV1(migrationBuilder);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            FunctionsMigrationHelper.DropGetPurchaseRequestUnusedItemsCountV1(migrationBuilder);
        }
    }
}
