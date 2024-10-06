using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.Data
{
    public partial class ProcDbContext : DbContext
    {
        [DbFunction(Name = "get_categories_by_level", Schema = "public", IsBuiltIn = false)]
        public IQueryable<CategoryResultSet> GetCategoriesByLevel(int level)
            => FromExpression(() => GetCategoriesByLevel(level));

        [DbFunction(Name = "get_material_with_categories", Schema = "public", IsBuiltIn = false)]
        public IQueryable<MaterialResultSet> GetMaterialWithCategories(int materialId)
            => FromExpression(() => GetMaterialWithCategories(materialId));

        [DbFunction(Name = "get_unused_purchase_request_items", Schema = "public", IsBuiltIn = false)]
        public IQueryable<UnusedPRItemInfoResultSet> GetUnusedPurchaseRequestItemsInfo(
            int pageNumber,
            int pageSize,
            string search)
            => FromExpression(() => GetUnusedPurchaseRequestItemsInfo(pageNumber, pageSize, search));

        [DbFunction(Name = "get_unused_purchase_request_items_by_ids", Schema = "public", IsBuiltIn = false)]
        public IQueryable<UnusedPRItemResultSet> GetUnusedPurchaseRequestItemsByIds(int[] prItemIds)
            => FromExpression(() => GetUnusedPurchaseRequestItemsByIds(prItemIds));

        [DbFunction(Name = "get_user_roles_with_delegated_roles", Schema = "public", IsBuiltIn = false)]
        public IQueryable<UserRoleResultSet> GetUserRolesWithDelegatedRoles(int userId, int delegatedUserId)
            => FromExpression(() => GetUserRolesWithDelegatedRoles(userId, delegatedUserId));
    }
}
