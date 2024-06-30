using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations
{
    public class DashboardConfiguration : IEntityTypeConfiguration<Dashboard>
    {
        public void Configure(EntityTypeBuilder<Dashboard> builder)
        {
            builder.Property(d => d.Name)
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

            builder.HasMany(d => d.Users)
                .WithOne(u => u.Dashboard)
                .HasForeignKey(u => u.DashboardId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}