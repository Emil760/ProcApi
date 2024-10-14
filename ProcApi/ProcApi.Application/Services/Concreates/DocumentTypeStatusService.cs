using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.DocumentTypeStatus.Requests;
using ProcApi.Application.DTOs.DocumentTypeStatus.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates
{
    public class DocumentTypeStatusService : IDocumentTypeStatusService
    {
        private readonly IDocumentTypeStatusRepository _documentTypeStatusRepository;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DocumentTypeStatusService(IDocumentTypeStatusRepository documentTypeStatusRepository,
            IStringLocalizer<SharedResource> localizer,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _documentTypeStatusRepository = documentTypeStatusRepository;
            _localizer = localizer;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(AddDocumentTypeStatusRequest dto)
        {
            if (!await _documentTypeStatusRepository.ExistsByTypeAndStatus(dto.DocumentType, dto.DocumentStatus))
                throw new ValidationException(_localizer[LocalizationKeys.DOCUMENT_TYPE_STATUS_ALREADY_EXISTS]);

            var entity = _mapper.Map<DocumentTypeStatus>(dto);
            await _documentTypeStatusRepository.InsertAsync(entity);
            return entity.Id;
        }

        public async Task<IEnumerable<DocumentTypeStatusResponse>> GetAllAsync()
        {
            var entities = await _documentTypeStatusRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<DocumentTypeStatusResponse>>(entities);
        }

        public async Task<IEnumerable<DocumentTypeStatusResponse>> GetAllByDocumentTypeAsync(DocumentType documentType)
        {
            var entities = await _documentTypeStatusRepository.GetAllByType(documentType);

            return _mapper.Map<IEnumerable<DocumentTypeStatusResponse>>(entities);
        }
    }
}
