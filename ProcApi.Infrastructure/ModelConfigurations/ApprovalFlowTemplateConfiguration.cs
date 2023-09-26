using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations
{
    public class ApprovalFlowTemplateConfiguration : IEntityTypeConfiguration<ApprovalFlowTemplate>
    {
        public void Configure(EntityTypeBuilder<ApprovalFlowTemplate> builder)
        {
            builder.Property(aft => aft.IsCreator)
                .HasColumnType("boolean")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(aft => aft.IsInitial)
                .HasColumnType("boolean")
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
