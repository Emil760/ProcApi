using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Presentation.Controllers;


[ApiController]
[Route("[controller]")]
public class DepartmentController
{
    private readonly IDepartmentService _departmentService;
    
    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
}