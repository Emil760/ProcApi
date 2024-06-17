using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations;

public class GoodIssueNoteItemConfiguration : IEntityTypeConfiguration<GoodIssueNoteItem>
{
    public void Configure(EntityTypeBuilder<GoodIssueNoteItem> builder)
    {
        throw new NotImplementedException();
    }
}