﻿using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IUnitOfMeasureConverterRepository : IGenericRepository<UnitOfMeasureConverter, int>
{
    Task<bool> ExistsBySourceAndTargetId(int sourceId, int targetId);
    Task<UnitOfMeasureConverter?> GetBySourceIdAndTargetId(int sourceId, int targetId);
}