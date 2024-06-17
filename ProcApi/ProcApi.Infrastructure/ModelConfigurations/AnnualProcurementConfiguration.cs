using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class AnnualProcurementConfiguration : IEntityTypeConfiguration<AnnualProcurement>
{
    public void Configure(EntityTypeBuilder<AnnualProcurement> builder)
    {
        throw new NotImplementedException();
    }
}