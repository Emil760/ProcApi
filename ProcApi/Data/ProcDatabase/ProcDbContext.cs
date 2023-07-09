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
        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
