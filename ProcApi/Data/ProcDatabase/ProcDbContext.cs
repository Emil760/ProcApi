using Microsoft.EntityFrameworkCore;
using ProcApi.Data.ProcDatabase.Models;
using System.Reflection;

namespace ProcApi.Data.ProcDatabase
{
    public class ProcDbContext : DbContext
    {
        public ProcDbContext(DbContextOptions<ProcDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ApprovalFlowTemplate> ApprovalFlowTemplates { get; set; }
        public DbSet<ControlSet> ControlSets { get; set; }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentAction> DocumentActions { get; set; }
        public DbSet<InvoiceDocument> InvoiceDocuments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<PurchaseRequestDocument> PurchaseRequestDocuments { get; set; }
        public DbSet<PurchaseRequestDocumentItem> PurchaseRequestDocumentItems { get; set; }
        public DbSet<ReleaseStrategy> ReleaseStrategies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
        public DbSet<FeatureConfiguration> Configurations { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
