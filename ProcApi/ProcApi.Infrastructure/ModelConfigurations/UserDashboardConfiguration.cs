using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class UserDashboardConfiguration : IEntityTypeConfiguration<UserDashboard>
{
    public void Configure(EntityTypeBuilder<UserDashboard> builder)
    {
        builder.Property(x => x.Name)
            .HasColumnType("varchar(300)")
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(u => u.UserDashboards)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.ForegroundColor)
            .HasColumnType("varchar(300)");

        builder.Property(x => x.BackgroundColor)
            .HasColumnType("varchar(300)");

        builder.HasMany(x => x.Sections)
            .WithOne(s => s.UserDashboard)
            .HasForeignKey(x => x.UserDashboardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}