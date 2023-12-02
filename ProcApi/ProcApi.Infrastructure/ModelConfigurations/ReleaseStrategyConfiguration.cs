using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class ReleaseStrategyConfiguration : IEntityTypeConfiguration<ReleaseStrategy>
{
    public void Configure(EntityTypeBuilder<ReleaseStrategy> builder)
    {
    }
}