using Microsoft.EntityFrameworkCore.Migrations;
using ProcApi.Domain.Enums;

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
        migrationBuilder.Sql(@$"CREATE FUNCTION get_unused_purchase_request_items (pageNumber int, pageSize int, search varchar(300))
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
							      WHERE di.""DocumentStatusId"" != {DocumentStatus.InvoiceDraft}
							      AND (dp.""Number"" LIKE search OR m.""Name"" LIKE search)
							      GROUP BY prdi.""Id"", dp.""Number"", m.""Name""
							      ORDER BY dp.""Number""
							      OFFSET ((pageNumber - 1) * pageSize) ROWS FETCH FIRST pageSize ROWS ONLY;
							   END;
							   $$
							   LANGUAGE PLPGSQL");
    }

    public static void DropGetUnusedPurchaseRequestItemsCountV1(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS get_unused_purchase_request_items");
    }

    public static void CreateGetUnusedPurchaseRequestItemsCountV2(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@$"create function get_unused_purchase_request_items(pagenumber integer, pagesize integer, search character varying)
                               returns TABLE(""PurchaseRequestItemId"" integer, ""PurchaseRequestNumber"" character varying, ""MaterialName"" character varying, ""Quantity"" numeric, ""UnusedQuantity"" numeric)
                               language plpgsql
                               as
                               $$
                               BEGIN
                                  RETURN QUERY
                                  SElECT prdi.""Id"" as ""PurchaseRequestItemId"",
                                  dp.""Number"" as ""PurchaseRequestNumber"",
                                  m.""Name"" as ""MaterialName"",
                                  prdi.""Quantity"" as ""Count"",
                                  coalesce(prdi.""Quantity"" - (SELECT coalesce(sum(idi.""Quantity""), 0)
                                                                FROM ""InvoiceDocumentItems"" idi
                                                                INNER JOIN ""Documents"" di ON di.""Id"" = idi.""InvoiceId""
                                                                INNER JOIN ""Materials"" m ON prdi.""MaterialId"" = m.""Id""
                                                                WHERE di.""DocumentStatusId"" not in ({(int)DocumentStatus.InvoiceDraft}, {(int)DocumentStatus.InvoiceCanceled}, {(int)DocumentStatus.InvoiceRejected})
                                                                AND idi.""PurchaseRequestItemId"" = prdi.""Id"")) as ""UnusedQuantity""
                                  FROM ""PurchaseRequestItems"" prdi
                                  INNER JOIN ""Documents"" dp on dp.""Id"" = prdi.""PurchaseRequestId""
                                  INNER JOIN ""Materials"" m ON prdi.""MaterialId"" = m.""Id""
                                  AND (dp.""Number"" LIKE search OR m.""Name"" LIKE search)
                                  GROUP BY prdi.""Id"", dp.""Number"", m.""Name""
                                  ORDER BY dp.""Number""
							      OFFSET ((pageNumber - 1) * pageSize) ROWS FETCH FIRST pageSize ROWS ONLY;
                               END;
                               $$;");
    }

    public static void DropGetUnusedPurchaseRequestItemsCountV2(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"DROP FUNCTION IF EXISTS get_unused_purchase_request_items");
    }

    #endregion

    #region GetUnusedPurchaseRequestItemsByIds

    public static void CreateGetUnusedPurchaseRequestItemsByIdsV1(MigrationBuilder builder)
    {
        builder.Sql($@"CREATE FUNCTION get_unused_purchase_request_items_by_ids (prItemIds int[])
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
                                                      AND idd.""DocumentStatusId"" not in ({(int)DocumentStatus.InvoiceDraft}, {(int)DocumentStatus.InvoiceCanceled}, {(int)DocumentStatus.InvoiceRejected})), 0) as ""UnusedCount""
                          FROM ""PurchaseRequestItems"" prdi
                          INNER JOIN ""Documents"" prd on prd.""Id"" = prdi.""PurchaseRequestId""
                          WHERE prd.""DocumentStatusId"" = 100 AND prdi.""Id"" = ANY (prItemIds);
					  END;
					  $$
					  LANGUAGE PLPGSQL");
    }

    public static void DropGetUnusedPurchaseRequestItemsByIdsV1(MigrationBuilder builder)
    {
        builder.Sql(@"DROP FUNCTION IF EXISTS get_unused_purchase_request_items_by_ids");
    }

    public static void CreateGetUnusedPurchaseRequestItemsByIdsV2(MigrationBuilder builder)
    {
        builder.Sql($@"create function get_unused_purchase_request_items_by_ids(pritemids integer[])
                      returns TABLE(""PurchaseRequestItemId"" integer, ""Price"" numeric, ""UnusedCount"" numeric)
                      language plpgsql
                      as
                      $$
                      	BEGIN
                      	    RETURN QUERY
                      	    SELECT prdi.""Id"",
                                          prdi.""Price"",
                                          prdi.""Quantity"" - COALESCE((SELECT SUM(idi.""Quantity"")
                                                                      FROM ""InvoiceDocumentItems"" idi
                                                                      INNER JOIN ""Documents"" idd on idd.""Id"" = idi.""InvoiceId""
                                                                      WHERE idi.""PurchaseRequestItemId"" = prdi.""Id""
                                                                      AND idd.""DocumentStatusId"" not in ({(int)DocumentStatus.InvoiceDraft}, {(int)DocumentStatus.InvoiceCanceled}, {(int)DocumentStatus.InvoiceRejected})), 0)
                                          FROM ""PurchaseRequestItems"" prdi
                                          INNER JOIN ""Documents"" prd on prd.""Id"" = prdi.""PurchaseRequestId""
                                          WHERE prd.""DocumentStatusId"" = {(int)DocumentStatus.PurchaseRequestApproved} AND prdi.""Id"" = ANY (prItemIds);
                      	END;
                      	$$;");
    }

    public static void DropGetUnusedPurchaseRequestItemsByIdsV2(MigrationBuilder builder)
    {
	    builder.Sql(@"DROP FUNCTION IF EXISTS get_unused_purchase_request_items_by_ids");
    }

    #endregion

    #region GetUserRolesWithDelegatedRoles

    public static void CreateGetUserRolesWithDelegatedRolesV1(MigrationBuilder builder)
    {
        builder.Sql(@"create function get_user_roles_with_delegated_roles(userId int, delegatedUserId int)
					  returns table (
					  ""UserId"" int,
					  ""RoleId"" int
					  )
					  as
					  $$
					  begin
						  return query
					      select u.""Id"" as ""UserId"", ur.""RoleId"" as ""RoleId""
					      from ""Users"" u
					      inner join ""UserRoles"" ur on u.""Id"" = ur.""UserId""
					      where u.""Id"" = userId
					  
					      union
					  
					      select d.""FromUserId"" as ""UserId"", ur.""RoleId"" as ""RoleId""
					      from ""Delegations"" d
					      inner join ""UserRoles"" ur on ur.""UserId"" = d.""FromUserId""
					      where d.""FromUserId"" = delegatedUserId and d.""ToUserId"" = userId and d.""EndDate"" >= current_date;
					  end;
					  $$
					  language PLPGSQL");
    }

    public static void DropGetUserRolesWithDelegatedRolesV1(MigrationBuilder builder)
    {
        builder.Sql("drop function if exists get_user_roles_with_delegated_roles");
    }

    #endregion
}