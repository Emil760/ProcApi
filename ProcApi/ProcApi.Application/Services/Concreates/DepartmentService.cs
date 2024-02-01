using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Application.DTOs.Department.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Constants;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentService(IDepartmentRepository departmentRepository,
        IUserRepository userRepository,
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer,
        IHttpContextAccessor httpContextAccessor,
        IUnitOfWork unitOfWork)
    {
        _departmentRepository = departmentRepository;

        _userRepository = userRepository;
        _mapper = mapper;
        _localizer = localizer;
        _httpContextAccessor = httpContextAccessor;
        _unitOfWork = unitOfWork;
    }

    public async Task<DepartmentResponseDto> CreateDepartmentAsync(CreateDepartmentDto dto)
    {
        var user = await _userRepository.GetByIdAndRoleId(dto.HeadUserId, Roles.HeadDepartment);
        if (user is null)
            throw new NotFoundException(_localizer["UserNotFound"]);

        var departmentExists = await _departmentRepository.ExistsByName(dto.Name);
        if (departmentExists)
            throw new ValidationException(_localizer["DepartmentNameAlreadyExists"]);

        var department = _mapper.Map<Department>(dto);
        user.Department = department;

        _departmentRepository.Insert(department);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<DepartmentResponseDto>(department);
    }

    public async Task AssignUserToDepartment(int userId, AssignUserDepartmentDto dto)
    {
        var department = await _departmentRepository.GetByIdAsync(dto.DepartmentId);

        if (department is null)
            throw new NotFoundException(_localizer["DepartmentNotFound"]);

        if (department.HeadUserId != userId)
            throw new ValidationException(_localizer["UserDontBelongToDepartment"]);

        var user = await _userRepository.GetByIdAsync(dto.UserId);
        if (user is null)
            throw new NotFoundException(_localizer["UserNotFound"]);

        user.Department = department;

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<DepartmentListResponseDto>> GetAllAsync(PaginationModel pagination)
    {
        var departmentPaginated = await _departmentRepository.GetAllPaginated(pagination);

        _httpContextAccessor.HttpContext!.Response.Headers.Add(HeaderKeys.XPagination, departmentPaginated.ToString());

        return _mapper.Map<IEnumerable<DepartmentListResponseDto>>(departmentPaginated.ResultSet);
    }
}