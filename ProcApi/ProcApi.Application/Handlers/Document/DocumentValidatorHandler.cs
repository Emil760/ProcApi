using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Handlers.Document;

public class DocumentValidatorHandler : IDocumentValidatorHandler
{
    private readonly IDocumentValidationConfigurationRepository _documentValidationConfigurationRepository;
    private readonly IDocumentRepository _documentRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IStringLocalizer<SharedResource> _localizer;

    public DocumentValidatorHandler(
        IDocumentValidationConfigurationRepository documentValidationConfigurationRepository,
        IDocumentRepository documentRepository,
        IHttpContextAccessor httpContextAccessor,
        IStringLocalizer<SharedResource> localizer)
    {
        _documentValidationConfigurationRepository = documentValidationConfigurationRepository;
        _documentRepository = documentRepository;
        _httpContextAccessor = httpContextAccessor;
        _localizer = localizer;
    }

    async Task IDocumentValidatorHandler.ValidateDocumentAsync(int documentId, Type validatorType)
    {
        var document = await _documentRepository.GetByIdAsync(documentId);
        if (document is null)
            throw new NotFoundException(_localizer["DocumentNotFound"]);

        var validations = await _documentValidationConfigurationRepository.GetActiveByTypeAndStatusAsync(
            document.DocumentTypeId,
            document.DocumentStatusId);

        var documentValidator = _httpContextAccessor.HttpContext?.RequestServices.GetRequiredService(validatorType);

        var initMethod = validatorType.GetMethod("InitAsync");
        var task = (Task)initMethod.Invoke(documentValidator, [documentId]);
        await task.ConfigureAwait(true);

        var errors = new List<string>();

        foreach (var validation in validations)
        {
            var myMethod = validatorType.GetMethod(validation.ValidationName);
            var errorMessage = await (Task<string?>)myMethod.Invoke(documentValidator, null);

            if (errorMessage is not null)
                errors.Add(errorMessage);
        }

        if (errors.Count == 0)
            throw new MultipleException(errors);
    }
}