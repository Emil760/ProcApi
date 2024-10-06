﻿using ProcApi.Domain.Entities;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IGroupRepository : IGenericRepository<Group, int>
{
    Task<IEnumerable<Group>> GetAllWithLastMessageByUserId(int userId);
}