﻿using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IAnnualProcurementRepository : IGenericRepository<AnnualProcurement, int>
{
    Task<bool> ExistsByYearAsync(short year);
    Task<bool> ExistsByYearAndActiveAsync(short year, bool isActive);
    Task<AnnualProcurement?> GetWithItemsByIdAsync(int id);
    Task<IEnumerable<AnnualProcurement>> GetAllActiveAsync();
}