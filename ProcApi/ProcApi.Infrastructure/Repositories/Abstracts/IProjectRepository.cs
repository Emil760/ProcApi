﻿using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IProjectRepository : IGenericRepository<Project>
{
    Task<bool> ExistsByNameAsync(string name);
}