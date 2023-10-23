using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Moq;
using ProcApi.Application.DTOs.Department.Requests;
using ProcApi.Application.DTOs.Department.Responses;
using ProcApi.Application.Services.Concreates;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Concreates;
using ProcApi.Infrastructure.Resources;
using Xunit;

namespace TestProject.UnitTest;

public class DepartmentTest : BaseTest
{
    private readonly UserRepository _userRepository;
    private readonly DepartmentRepository _departmentRepository;
    private readonly DepartmentService _departmentService;

    public DepartmentTest()
    {
        var localizer = new Mock<IStringLocalizer<SharedResource>>();
        var accessor = new Mock<IHttpContextAccessor>();

        _userRepository = new UserRepository(_context);

        _departmentRepository = new DepartmentRepository(_context);

        _departmentService = new DepartmentService(_departmentRepository,
            _userRepository,
            _mapper,
            localizer.Object,
            accessor.Object,
            _unitOfWork);

        SeedUsers();
        SeedDepartments();
    }

    private void SeedUsers()
    {
        _context.Users.Add(new User()
        {
            Id = 1,
            FirstName = "user1",
            Login = "user1",
            Roles = new List<Role>()
            {
                new Role()
                {
                    Id = (int)Roles.User,
                    Name = Roles.User.ToString()
                },
            }
        });

        _context.Users.Add(new User()
        {
            Id = 2,
            FirstName = "user2",
            Login = "user2",
            Roles = new List<Role>()
            {
                new Role()
                {
                    Id = (int)Roles.HeadDepartment,
                    Name = Roles.HeadDepartment.ToString()
                }
            }
        });

        _context.SaveChanges();
    }

    private void SeedDepartments()
    {
        _context.Departments.Add(new Department()
        {
            Id = 1,
            Name = "dep1"
        });

        _context.Departments.Add(new Department()
        {
            Id = 2,
            Name = "dep2"
        });

        _context.SaveChanges();
    }

    [Fact]
    public async Task Throw_When_Create_Department_With_Not_Head_Department_User()
    {
        var dto = new CreateDepartmentDto()
        {
            HeadUserId = 1,
            Name = "dep3"
        };

        await Assert.ThrowsAsync<NotFoundException>(() => _departmentService.CreateDepartmentAsync(dto));
    }

    [Fact]
    public async Task Throw_When_Department_Name_Already_Exists()
    {
        var dto = new CreateDepartmentDto()
        {
            HeadUserId = 2,
            Name = "dep1"
        };

        await Assert.ThrowsAsync<ValidationException>(() => _departmentService.CreateDepartmentAsync(dto));
    }

    [Fact]
    public async Task Create_Department_Success()
    {
        var dto = new CreateDepartmentDto()
        {
            HeadUserId = 2,
            Name = "dep3"
        };

        var response = await _departmentService.CreateDepartmentAsync(dto);
        Assert.IsType<DepartmentResponseDto>(response);
    }

    [Fact]
    public async Task Throw_When_User_Not_Found_While_Assign_To_Department()
    {
        var dto = new AssignUserDepartmentDto()
        {
            UserId = 3,
            DepartmentId = 1
        };

        await Assert.ThrowsAsync<NotFoundException>(() => _departmentService.AssignUserToDepartment(dto));
    }

    [Fact]
    public async Task Throw_When_Department_Not_Found_While_Assign_User()
    {
        var dto = new AssignUserDepartmentDto()
        {
            UserId = 1,
            DepartmentId = 3
        };

        await Assert.ThrowsAsync<NotFoundException>(() => _departmentService.AssignUserToDepartment(dto));
    }

    [Fact]
    public async Task Assign_User_To_Department_Success()
    {
        var dto = new AssignUserDepartmentDto()
        {
            UserId = 1,
            DepartmentId = 1
        };

        await _departmentService.AssignUserToDepartment(dto);
    }
}