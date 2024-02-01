namespace ProcApi.Application.Handlers.Document;

public interface IDocumentValidatorHandler
{
    Task ValidateDocumentAsync(int documentId, Type validatorType);
}