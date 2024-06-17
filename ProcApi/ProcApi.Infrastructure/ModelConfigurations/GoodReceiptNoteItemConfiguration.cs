using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class GoodReceiptNoteItemConfiguration : IEntityTypeConfiguration<GoodReceiptNoteItem>
{
    public void Configure(EntityTypeBuilder<GoodReceiptNoteItem> builder)
    {
        throw new NotImplementedException();
    }
}