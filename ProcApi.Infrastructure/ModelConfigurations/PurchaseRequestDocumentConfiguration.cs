using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations
{
    public class PurchaseRequestDocumentConfiguration : IEntityTypeConfiguration<PurchaseRequestDocument>
    {
        public void Configure(EntityTypeBuilder<PurchaseRequestDocument> builder)
        {
            builder.HasKey(prd => prd.DocumentId);

            builder.Property(prd => prd.DocumentId)
                .ValueGeneratedNever();

            builder.Property(prd => prd.Description)
                .HasMaxLength(4000)
                .HasDefaultValue("");

            builder.HasOne(prd => prd.Document)
                .WithOne()
                .HasForeignKey<PurchaseRequestDocument>(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(prd => prd.RequestedForDepartment)
                .WithMany()
                .HasForeignKey(prd => prd.RequestedForDepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(prd => prd.Project)
                .WithMany()
                .HasForeignKey(prd => prd.ProjectId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}