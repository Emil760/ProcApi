using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class FeatureConfigurationRepository : GenericRepository<FeatureConfiguration, int>, IFeatureConfigurationRepository
{
    public FeatureConfigurationRepository(ProcDbContext context) : base(context)
    {
    }

    public async Task<string> GetByTypeAndNameAsync(ConfigurationType type, string name)
    {
        return await _context.FeatureConfigurations
            .Where(fc => fc.ConfigurationType == type && fc.Name == name)
            .Select(fc => fc.Value)
            .SingleAsync();
    }
}