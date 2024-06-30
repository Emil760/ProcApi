using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.Comparers;
using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.DTOs.User.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IDashboardRepository _dashboardRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public UserService(IUserRepository userRepository,
        IDashboardRepository dashboardRepository,
        IDepartmentRepository departmentRepository,
        IRoleRepository roleRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IStringLocalizer<SharedResource> localizer)
    {
        _userRepository = userRepository;
        _dashboardRepository = dashboardRepository;
        _roleRepository = roleRepository;
        _departmentRepository = departmentRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _localizer = localizer;
    }

    public async Task<UserResponseDto> AddUserAsync(AddUserDto dto)
    {
        var user = _mapper.Map<User>(dto);

        _userRepository.Insert(user);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<IEnumerable<string>> GetAllRoleNames(int userId)
    {
        var roles = await _userRepository.GetRolesUnionDelegatedRoles(userId);

        var roleNames = roles.Select(r => ((Roles)r).ToString());

        return roleNames;
    }

    public async Task<IEnumerable<string>> GetPermissionNames(int userId)
    {
        return await _userRepository.GetPermissionsUnionDelegatedPermissions(userId);
    }

    public async Task<UserInfoResponseDto> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetAllInfoByIdAsync(id);

        if (user is null)
            throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND]);

        return _mapper.Map<UserInfoResponseDto>(user);
    }

    public async Task<IEnumerable<UserInfoResponseDto>> GetAllInfosAsync()
    {
        var users = await _userRepository.GetAllInfosAsync();

        users = users.OrderByDescending(u => u.Gender, new GenderComparer());

        return _mapper.Map<IEnumerable<UserInfoResponseDto>>(users);
    }

    public async Task<IEnumerable<UserWithRolesResponseDto>> GetUsersWithRolesAsync(string? search)
    {
        search ??= "";

        var users = await _userRepository.GetAllWithRoles(search);

        return _mapper.Map<IEnumerable<UserWithRolesResponseDto>>(users);
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllByRoleAsync(int roleId)
    {
        var users = await _userRepository.GetAllByRoleAsync(roleId);

        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    public async Task<IEnumerable<UserResponseDto>> GetAllByRoleNameAsync(string name)
    {
        var users = await _userRepository.GetAllByRoleNameAsync(name);

        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }

    public async Task GrantRoleAsync(GrantRoleRequestDto dto)
    {
        var user = await _userRepository.GetWithRolesById(dto.UserId);
        if (user is null)
            throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND]);

        var role = await _roleRepository.GetByIdAsync(dto.RoleId);
        if (role is null)
            throw new NotFoundException(_localizer[LocalizationKeys.ROLE_NOT_FOUND]);

        if (user.Roles.Any(r => r.Id == dto.RoleId))
            throw new ValidationException(_localizer[LocalizationKeys.USER_ALREDY_HAS_ROLE]);

        user.Roles.Add(role);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveRoleAsync(RemoveRoleRequestDto dto)
    {
        var user = await _userRepository.GetWithRolesById(dto.UserId);
        if (user is null)
            throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND]);

        var role = await _roleRepository.GetByIdAsync(dto.RoleId);
        if (role is null)
            throw new NotFoundException(_localizer[LocalizationKeys.ROLE_NOT_FOUND]);

        user.Roles.Remove(role);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AssignDashboardAsync(AssignDashboardRequestDto dto)
    {
        var user = await _userRepository.GetWithRolesById(dto.UserId);
        if (user is null)
            throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND]);

        var dashboard = await _dashboardRepository.GetByIdAsync(dto.DashboardId);
        if (dashboard is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DASHBOARD_NOT_FOUND]);

        user.Dashboard = dashboard;
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AssignDepartmentAsync(AssignDepartmentRequestDto dto)
    {
        var user = await _userRepository.GetByIdAsync(dto.UserId);
        if (user is null)
            throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND]);
        
        var department = await _departmentRepository.GetByIdAsync(dto.DepartmentId);
        if (department is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DEPARTMENT_NOT_FOUND]);
        
        if (department.Id == user.DepartmentId)
            throw new ValidationException(_localizer[LocalizationKeys.USER_ALREADY_HAS_DEPARTMENT]);

        user.Department = department;
        await _unitOfWork.SaveChangesAsync();
    }
}