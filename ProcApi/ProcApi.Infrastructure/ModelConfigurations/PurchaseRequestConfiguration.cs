using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class PurchaseRequestConfiguration : IEntityTypeConfiguration<PurchaseRequest>
{
    public void Configure(EntityTypeBuilder<PurchaseRequest> builder)
    {
        builder.HasKey(prd => prd.Id);

        builder.Property(prd => prd.Id)
            .ValueGeneratedNever();

        builder.HasOne(prd => prd.Document)
            .WithOne()
            .HasForeignKey<PurchaseRequest>(prd => prd.Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(prd => prd.Description)
            .HasMaxLength(4000)
            .IsRequired(false);
        
        builder.Property(prd => prd.DeliveryAddress)
            .HasMaxLength(300)
            .IsRequired(false);

        builder.HasOne(prd => prd.RequestedForDepartment)
            .WithMany()
            .HasForeignKey(prd => prd.RequestedForDepartmentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(prd => prd.Project)
            .WithMany()
            .HasForeignKey(prd => prd.ProjectId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(prd => prd.TotalItemsPrice)
            .HasColumnType("decimal")
            .IsRequired()
            .HasDefaultValue(0);
    }
}