using ProcApi.Application.DTOs.DocumentPattern.Requests;
using ProcApi.Application.DTOs.DocumentPattern.Responses;

namespace ProcApi.Application.Services.Abstracts;

public interface IDocumentNumberPatternService
{
    Task<int> CreatePatternAsync(CreateDocumentNumberPatternRequest dto);
    Task ActivatePatternAsync(ActivateDocumentNumberPatternRequest dto);
    Task ChnageDocumentNumberPatterAsync(ChangeDocumentNumberPatternRequest dto);
    Task<int> AddSectionAsync(CreateDocumentNumberSectionRequest dto);
    Task<IEnumerable<DocumentNumberSectionReponse>> GetSectionAsync(int documentDocumentPatterId);
    Task<IEnumerable<DocumentNumberPatternReponse>> GetPatternsAsync();
}