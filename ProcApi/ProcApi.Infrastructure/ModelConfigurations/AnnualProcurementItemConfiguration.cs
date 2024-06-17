using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class AnnualProcurementItemConfiguration : IEntityTypeConfiguration<AnnualProcurementItem>
{
    public void Configure(EntityTypeBuilder<AnnualProcurementItem> builder)
    {
        throw new NotImplementedException();
    }
}