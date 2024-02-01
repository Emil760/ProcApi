namespace ProcApi.Application.Services.Abstracts;

public interface IDocumentValidator
{
    Task InitAsync(int documentId);
}