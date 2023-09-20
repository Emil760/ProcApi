using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProcApi.Data.ProcDatabase.Models;

namespace ProcApi.Data.ProcDatabase.Configurations
{
    public class ReleaseStrategyConfiguration : IEntityTypeConfiguration<ReleaseStrategy>
    {
        public void Configure(EntityTypeBuilder<ReleaseStrategy> builder)
        {
            throw new NotImplementedException();
        }

        private void SeedData()
        {
            new List<ReleaseStrategy>
            {
                new ReleaseStrategy()
                {

                },
                new ReleaseStrategy()
                {

                }
            };
        }
    }
}
