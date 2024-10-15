using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.DocumentPattern.Requests;
using ProcApi.Application.DTOs.DocumentPattern.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class DocumentNumberPatternService : IDocumentNumberPatternService
{
    private readonly IDocumentNumberSectionRepository _documentNumberSectionRepository;
    private readonly IDocumentNumberPatterRepository _documentNumberPatterRepository;
    private readonly IDocumentRepository _documentRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public DocumentNumberPatternService(IDocumentNumberSectionRepository documentNumberSectionRepository,
        IDocumentNumberPatterRepository documentNumberPatterRepository,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IStringLocalizer<SharedResource> localizer,
        IDocumentRepository documentRepository)
    {
        _documentNumberSectionRepository = documentNumberSectionRepository;
        _documentNumberPatterRepository = documentNumberPatterRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _localizer = localizer;
        _documentRepository = documentRepository;
    }

    public async Task<int> CreatePatternAsync(CreateDocumentNumberPatternRequest dto)
    {
        var hasActive = await _documentNumberPatterRepository.HasActiveByDocumentTypeAsync(dto.DocumentType);
        if (hasActive)
            throw new ValidationException(_localizer[LocalizationKeys.HAS_ACTIVE_DOCUMENT_NUMBER_PATTERN]);

        var entity = _mapper.Map<DocumentNumberPattern>(dto);
        await _documentNumberPatterRepository.InsertAsync(entity);
        return entity.Id;
    }

    public async Task ActivatePatternAsync(ActivateDocumentNumberPatternRequest dto)
    {
        var entity = await _documentNumberPatterRepository.GetByIdAsync(dto.Id);
        if (entity is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NUMBER_PATTERN_NOT_FOUND]);

        entity.IsActive = dto.IsActive;
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ChnageDocumentNumberPatterAsync(ChangeDocumentNumberPatternRequest dto)
    {
        var entity = await _documentNumberPatterRepository.GetByIdAsync(dto.Id);
        if (entity is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NUMBER_PATTERN_NOT_FOUND]);

        entity.Name = dto.Name;
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<int> AddSectionAsync(CreateDocumentNumberSectionRequest dto)
    {
        if (!await _documentNumberPatterRepository.ExistsByIdAsync(dto.DocumentNumberPatternId))
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NUMBER_PATTERN_NOT_FOUND]);

        var hasUsedDocuments = await _documentRepository.HasByDocumentNumberPatternId(dto.DocumentNumberPatternId);
        if (hasUsedDocuments)
            throw new ValidationException(_localizer[LocalizationKeys.HAS_USED_DOCUMENTS]);

        var sections = await _documentNumberSectionRepository.GetByDocumentNumberPatterIdAsync(dto.DocumentNumberPatternId);

        if (sections.Any(x => x.Order == dto.Order))
            throw new ValidationException(_localizer[LocalizationKeys.DOCUMENT_NUMBER_SECTION_WITH_SAME_ORDER]);

        var section = _mapper.Map<DocumentNumberSection>(dto);

        await _documentNumberSectionRepository.InsertAsync(section);

        return section.Id;
    }

    public async Task DeleteSectionAsync(int id)
    {
        var section = await _documentNumberSectionRepository.GetByIdAsync(id);
        if (section is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NUMBER_SECTION_NOT_FOUND]);

        var hasUsedDocuments = await _documentRepository.HasByDocumentNumberPatternId(section.DocumentNumberPatternId);
        if (hasUsedDocuments)
            throw new ValidationException(_localizer[LocalizationKeys.HAS_USED_DOCUMENTS]);

        await _documentNumberSectionRepository.DeleteAsync(section);
    }

    public async Task<IEnumerable<DocumentNumberSectionReponse>> GetSectionAsync(int documentDocumentPatterId)
    {
        var sections = await _documentNumberSectionRepository.GetByDocumentNumberPatterIdAsync(documentDocumentPatterId);

        return _mapper.Map<IEnumerable<DocumentNumberSectionReponse>>(sections);
    }

    public async Task<IEnumerable<DocumentNumberPatternReponse>> GetPatternsAsync()
    {
        var patterns = await _documentNumberPatterRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<DocumentNumberPatternReponse>>(patterns);
    }
}