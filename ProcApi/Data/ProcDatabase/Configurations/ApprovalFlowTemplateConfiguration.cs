using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations
{
    public class ApprovalFlowTemplateConfiguration : IEntityTypeConfiguration<ApprovalFlowTemplate>
    {
        public void Configure(EntityTypeBuilder<ApprovalFlowTemplate> builder)
        {
            // builder.HasOne(aft => aft.User)
            //     .WithMany(u => u.ApprovalFlowTemplates)
            //     .HasForeignKey(aft => aft.UserId)
            //     .OnDelete(DeleteBehavior.SetNull);

            builder.Property(aft => aft.IsCreator)
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(aft => aft.IsInitial)
                .HasColumnType("bit")
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
