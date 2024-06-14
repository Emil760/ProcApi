﻿using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;

namespace ProcApi.Infrastructure.Repositories.Abstracts
{
    public interface IFeatureConfigurationRepository : IGenericRepository<FeatureConfiguration>
    {
        Task<string> GetByTypeAndNameAsync(ConfigurationType type, string name);
    }
}
