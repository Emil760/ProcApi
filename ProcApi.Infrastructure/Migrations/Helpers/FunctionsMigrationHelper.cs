using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcApi.Infrastructure.Migrations.Helpers;

public static class FunctionsMigrationHelper
{
    #region GetCategoriesByLevel

    public static void CreateGetCategoriesByLevelV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"CREATE OR REPLACE FUNCTION get_categories_by_level (treeLevel INT)
                               RETURNS TABLE (
                                   ""Id"" int,
                                   ""Name"" varchar
                               ) AS
                               $$
                               BEGIN
                                       RETURN QUERY
                                       WITH RECURSIVE RecursiveTree AS (
                                       SELECT c.""Id"", c.""Name"", 0 AS ""Level""
                                       FROM ""Categories"" c
                                       WHERE ""ParentCategoryId"" IS NULL
                               
                                       UNION ALL
                                       SELECT c.""Id"", c.""Name"", r.""Level"" + 1 as ""Level""
                                       FROM ""Categories"" c
                                       INNER JOIN RecursiveTree r ON r.""Id"" = c.""ParentCategoryId""
                                       )
                                       SELECT rt.""Id"" AS ""Id"", rt.""Name"" as ""Name""
                                       FROM RecursiveTree rt
                                       WHERE rt.""Level"" = treeLevel;
                               END;
                               $$
                               LANGUAGE PLPGSQL");
    }

    public static void DropGetCategoriesByLevelV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS get_categories_by_level");
    }

    #endregion

    #region GetMaterialWithCategories

    public static void CreateGetMaterialWithCategoriesV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"CREATE OR REPLACE FUNCTION get_material_with_categories(materialId int)
                               RETURNS TABLE (
                               	 ""Id"" int,
                               	 ""Name"" varchar(300),
                                 ""Code"" varchar(300),
                               	 ""CategoryId"" int,
                               	 ""CategoryName"" varchar(300),
                               	 ""Level"" int
                               ) AS
                               $$
                               BEGIN
                               	RETURN QUERY
                               	WITH RECURSIVE RecursiveCTE  AS(
                                   SELECT m.""Id"" AS ""Id"",
                               	m.""Name"" AS ""Name"",
                                m.""Code"" AS ""Code"", 
                               	c.""Id"" AS ""CategoryId"",
                               	c.""Name"" as ""CategoryName"",
                               	c.""ParentCategoryId"" as ""ParentCategoryId"",
                               	0 AS ""Level""
                                   FROM ""Materials"" m
                                   INNER JOIN ""Categories"" c on c.""Id"" = m.""CategoryId""
                                   WHERE m.""Id"" = 1
                               
                                   union all
                               
                                   SELECT rt.""Id"" AS ""Id"",
                               	rt.""Name"" AS ""Name"",
                                rt.""Code"" AS ""Code"",
                               	c.""Id"" as ""CategoryId"",
                               	c.""Name"" as ""CategoryName"",
                               	c.""ParentCategoryId"" as ""ParentCategoryId"",
                               	rt.""Level"" + 1 as ""Level""
                                   FROM RecursiveCTE rt
                                   INNER JOIN ""Categories"" c on c.""Id"" = rt.""ParentCategoryId""
                                   WHERE rt.""ParentCategoryId"" is not null
                               )
                               SELECT rc.""Id"", rc.""Name"", rc.""Code"", rc.""CategoryId"", rc.""CategoryName"", rc.""Level""
                               FROM RecursiveCTE rc;
                               END;
                               $$
                               LANGUAGE 'plpgsql'");
    }

    public static void DropGetMaterialWithCategoriesV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"DROP IF EXISTS FUNCTION get_material_with_categories");
    }

    #endregion

    #region GetPurchaseRequestUnusedCount

    public static void CreateGetUnusedPurchaseRequestItemsCountV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"CREATE FUNCTION get_unused_purchase_request_items (pageNumber int, pageSize int, search varchar(300))
							   RETURNS TABLE (
							       ""PurchaseRequestItemId"" int,
							       ""PurchaseRequestNumber"" varchar(300),
							       ""MaterialName"" varchar(300),
							       ""Quantity"" decimal,
							       ""UnusedCount"" decimal
							   ) AS
							   $$
							   BEGIN
							      RETURN QUERY
							      SElECT prdi.""Id"" as ""PurchaseRequestItemId"",
							      dp.""Number"" as ""PurchaseRequestNumber"",
							      m.""Name"" as ""MaterialName"",
							      prdi.""Quantity"" as ""Count"",
							      prdi.""Quantity"" - sum(idi.""Quantity"") as ""UnusedCount""
							      FROM ""PurchaseRequestItems"" prdi
							      INNER JOIN ""InvoiceItems"" idi ON prdi.""Id"" = idi.""PurchaseRequestItemId""
							      INNER JOIN ""Documents"" di ON di.""Id"" = idi.""InvoiceId""
							      INNER JOIN ""Documents"" dp on dp.""Id"" = prdi.""PurchaseRequestId""
							      INNER JOIN ""Materials"" m ON prdi.""MaterialId"" = m.""Id""
							      WHERE di.""StatusId"" != 300
							      AND (dp.""Number"" LIKE search OR m.""Name"" LIKE search)
							      GROUP BY prdi.""Id"", dp.""Number"", m.""Name""
							      OFFSET ((pageNumber - 1) * pageSize) ROWS FETCH FIRST pageSize ROWS ONLY;
							   END;
							   $$
							   LANGUAGE PLPGSQL");
    }

    public static void DropGetUnusedPurchaseRequestItemsCountV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"DROP FUNCTION get_unused_purchase_request_items");
    }

    #endregion

    #region GetUnusedPurchaseRequestItemsByIds

    public static void CreateGetUnusedPurchaseRequestItemsByIdsV1(MigrationBuilder builder)
    {
	    builder.Sql(@"CREATE FUNCTION get_unused_purchase_request_items_by_ids (prItemIds int[])
					  RETURNS TABLE (
					      ""PurchaseRequestItemId"" int,
					      ""Price"" decimal,
					      ""UnusedCount"" decimal
					  )
					  AS
					  $$
					  BEGIN
					      RETURN QUERY
					      SELECT prdi.""Id"",
                          prdi.""Price"",
                          prdi.""Quantity"" - COALESCE((SELECT SUM(idi.""Quantity"")
                                                      FROM ""InvoiceItems"" idi
                                                      INNER JOIN ""Documents"" idd on idd.""Id"" = idi.""InvoiceId""
                                                      WHERE idi.""PurchaseRequestItemId"" = prdi.""Id""
                                                      AND idd.""StatusId"" != 300), 0)
                          FROM ""PurchaseRequestItems"" prdi
                          INNER JOIN ""Documents"" prd on prd.""Id"" = prdi.""PurchaseRequestId""
                          WHERE prd.""StatusId"" != 100 AND prdi.""Id"" = ANY (prItemIds);
					  END;
					  $$
					  LANGUAGE PLPGSQL");
    }

    public static void DropGetUnusedPurchaseRequestItemsByIdsV1(MigrationBuilder builder)
    {
	    builder.Sql(@"DROP FUNCTION get_unused_purchase_request_items_by_ids");
    }

    #endregion
}