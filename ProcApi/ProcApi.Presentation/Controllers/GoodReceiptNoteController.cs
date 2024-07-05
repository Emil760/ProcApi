using Microsoft.AspNetCore.Mvc;
using ProcApi.Application.Services.Abstracts;

namespace ProcApi.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class GoodReceiptNoteController : BaseController
{
    private readonly IGoodReceiptNoteService _goodReceiptNoteService;
    
    public GoodReceiptNoteController(IGoodReceiptNoteService goodReceiptNoteService)
    {
        _goodReceiptNoteService = goodReceiptNoteService;
    }
}