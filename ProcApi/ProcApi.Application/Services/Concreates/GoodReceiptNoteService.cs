using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class GoodReceiptNoteService : IGoodReceiptNoteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;
    
    public GoodReceiptNoteService(IUnitOfWork unitOfWork, 
        IMapper mapper,
        IStringLocalizer<SharedResource> localizer)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _localizer = localizer;
    }
}