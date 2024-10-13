﻿using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;
using ProcApi.Domain.ResultSets;
using ProcApi.Infrastructure.Utility;

namespace ProcApi.Infrastructure.Repositories.Abstracts;

public interface IUserRepository : IGenericRepository<User, int>
{
    Task<User> GetByIdCompiled(int id);
    Task<User?> GetAllInfoByIdAsync(int id);
    Task<IEnumerable<User>> GetByIdsAsync(params int[] ids);
    Task<IEnumerable<User>> GetAllAsync(IEnumerable<int> userIds);
    Task<Paginator<User>> GetAllPaginated(PaginationModel dto);
    Task<IEnumerable<User>> GetAllInfosAsync();
    Task<User?> GetWithRolesById(int id);
    Task<IEnumerable<User>> GetAllWithRoles(string search);
    Task<IEnumerable<User>> GetAllByRoleAsync(int roleId);
    Task<IEnumerable<User>> GetAllByRoleNameAsync(string name);
    Task<bool> ExistsByLogin(string login);
    Task<User?> GetWithPasswordHashByLogin(string login);
    Task<IEnumerable<string>> GetPermissions(int id);
    Task<IEnumerable<string>> GetPermissionsUnionDelegatedPermissions(int id);
    Task<IEnumerable<int>> GetRoles(int id);
    Task<IEnumerable<int>> GetRolesUnionDelegatedRoles(int id);
    Task<bool> HasRoleAsync(int id, Roles role);
    Task<User?> GetByIdAndRoleId(int userId, Roles role);
    Task<User?> GetDocumentAuthor(int docId);
    Task<IEnumerable<UserRoleResultSet>> GetUserRolesWithDelegatedRoles(int id, int delegatedUserId);
}