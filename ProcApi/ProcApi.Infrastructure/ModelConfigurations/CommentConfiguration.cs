using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.ModelConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<ControlSet>
    {
        public void Configure(EntityTypeBuilder<ControlSet> builder)
        {
            throw new NotImplementedException();
        }
    }
}
