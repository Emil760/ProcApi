using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.FunctionConfiguration;

public class GetUnusedPurchaseRequestItemsByIdsConfiguration : IEntityTypeConfiguration<UnusedPRItemResultSet>
{
    public void Configure(EntityTypeBuilder<UnusedPRItemResultSet> builder)
    {
        builder.HasNoKey();
        builder.ToFunction("get_unused_purchase_request_items_by_ids");
    }
}