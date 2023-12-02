using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.Comparers;
using ProcApi.Application.DTOs.User.Requests;
using ProcApi.Application.DTOs.User.Responses;
using ProcApi.Application.Services.Abstracts;
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
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public UserService(IUserRepository userRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IStringLocalizer<SharedResource> localizer)
    {
        _userRepository = userRepository;
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

    public async Task<bool> AlreadyExists(string login)
    {
        var userLogin = await _userRepository.ExistsByLogin(login);
        return userLogin is not null;
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

    public async Task<UserResponseDto> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
            throw new NotFoundException(_localizer["UserNotFound"]);

        return _mapper.Map<UserResponseDto>(user);
    }

    public async Task<IEnumerable<UserResponseDto>> GetUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();

        users = users.OrderByDescending(u => u.Gender, new GenderComparer());

        return _mapper.Map<IEnumerable<UserResponseDto>>(users);
    }
}