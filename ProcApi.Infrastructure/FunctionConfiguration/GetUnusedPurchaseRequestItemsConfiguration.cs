using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.ResultSets;

namespace ProcApi.Infrastructure.FunctionConfiguration;

public class GetUnusedPurchaseRequestItemsConfiguration : IEntityTypeConfiguration<UnusedPurchaseRequestItemsResultSet>
{
    public void Configure(EntityTypeBuilder<UnusedPurchaseRequestItemsResultSet> builder)
    {
        builder.HasNoKey();
        builder.ToFunction("get_unused_purchase_request_items");
    }
}