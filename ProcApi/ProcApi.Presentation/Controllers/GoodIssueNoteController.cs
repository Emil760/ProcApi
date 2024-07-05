using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodIssueNoteController : BaseController
{
    private readonly IGoodIssueNoteService _goodIssueNoteService;
    
    public GoodIssueNoteController(IGoodIssueNoteService goodIssueNoteService)
    {
        _goodIssueNoteService = goodIssueNoteService;
    }
}