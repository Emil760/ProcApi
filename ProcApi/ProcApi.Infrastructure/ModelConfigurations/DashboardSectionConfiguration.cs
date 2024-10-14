using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations
{
    public class DashboardSectionConfiguration : IEntityTypeConfiguration<DashboardSection>
    {
        public void Configure(EntityTypeBuilder<DashboardSection> builder)
        {
            builder.HasOne(x => x.UserDashboard)
                .WithMany(ud => ud.Sections)
                .HasForeignKey(x => x.UserDashboardId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.DocumentTypeStatus)
                 .WithMany(dts => dts.DashboardSections)
                 .HasForeignKey(x => x.DocumentTypeStatusId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
