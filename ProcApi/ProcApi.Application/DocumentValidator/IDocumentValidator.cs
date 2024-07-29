namespace ProcApi.Application.DocumentValidator;

public interface IDocumentValidator
{
    Task InitAsync(int documentId);
}