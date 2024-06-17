﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProcApi.Domain.Entities;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.Data
{
    public partial class ProcDbContext : DbContext
    {
        public ProcDbContext(DbContextOptions<ProcDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory")
            {
                // Apply the value converter only for in-memory database
                modelBuilder.Entity<ChatMessage>()
                    .Property(c => c.ReceivedInfos)
                    .HasConversion(
                        v => JsonConvert.SerializeObject(v),
                        v => JsonConvert.DeserializeObject<ICollection<ReceivedInfo>>(v)
                    );
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ApprovalFlowTemplate> ApprovalFlowTemplates { get; set; }
        public DbSet<ReleaseStrategyTemplate> ReleaseStrategyTemplates { get; set; }
        public DbSet<ControlSet> ControlSets { get; set; }
        public DbSet<DocumentAction> DocumentActions { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<PurchaseRequestItem> PurchaseRequestItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<GoodReceiptNote> GoodReceiptNotes { get; set; }
        public DbSet<GoodReceiptNoteItem> GoodReceiptNoteItems { get; set; }
        public DbSet<GoodIssueNote> GoodIssueNotes { get; set; }
        public DbSet<GoodIssueNoteItem> GoodIssueNoteItems { get; set; }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<UnitOfMeasureConverter> UnitOfMeasureConverters { get; set; }
        public DbSet<FeatureConfiguration> Configurations { get; set; }
        public DbSet<AnnualProcurement> AnnualProcurements { get; set; }
        public DbSet<AnnualProcurementItem> AnnualProcurementItems { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<DocumentValidationConfiguration> DocumentValidationConfigurations { get; set; }
        public DbSet<FeatureConfiguration> FeatureConfigurations { get; set; }
    }

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