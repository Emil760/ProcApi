using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class GoodIssueNoteService : IGoodIssueNoteService
{
    private readonly IGoodIssueNoteRepository _goodIssueNoteRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public GoodIssueNoteService(IGoodIssueNoteRepository goodIssueNoteRepository,
        IUnitOfWork unitOfWork,
        IStringLocalizer<SharedResource> localizer,
        IMapper mapper)
    {
        _goodIssueNoteRepository = goodIssueNoteRepository;
        _unitOfWork = unitOfWork;
        _localizer = localizer;
        _mapper = mapper;
    }
}