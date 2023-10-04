using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Application.DTOs.Department.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Models;
using ProcApi.Infrastructure.Constants;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DepartmentService(IDepartmentRepository departmentRepository,
        IUserRepository userRepository,
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer,
        IHttpContextAccessor httpContextAccessor)
    {
        _departmentRepository = departmentRepository;

        _userRepository = userRepository;
        _mapper = mapper;
        _localizer = localizer;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<DepartmentResponseDto> CreateDepartmentAsync(CreateDepartmentDto dto)
    {
        var user = await _userRepository.GetByIdAsync(dto.HeadUserId);
        if (user is null)
            throw new NotFoundException(_localizer["UserNotFound"]);

        var departmentExists = await _departmentRepository.ExistsByName(dto.Name);
        if (departmentExists)
            throw new ValidationException(_localizer["DepartmentNameAlreadyExists"]);

        var department = _mapper.Map<Department>(dto);

        await _departmentRepository.InsertAsync(department);

        return _mapper.Map<DepartmentResponseDto>(department);
    }

    public async Task<IEnumerable<DepartmentResponseDto>> GetAllAsync(PaginationModel pagination)
    {
        var departmentPaginated = await _departmentRepository.GetAllPaginated(pagination);

        _httpContextAccessor.HttpContext!.Response.Headers.Add(HeaderKeys.XPagination, departmentPaginated.ToString());

        return _mapper.Map<IEnumerable<DepartmentResponseDto>>(departmentPaginated.ResultSet);
    }
}