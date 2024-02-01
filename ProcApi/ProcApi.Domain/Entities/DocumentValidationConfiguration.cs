using ProcApi.Domain.Enums;

namespace ProcApi.Domain.Entities;

public class DocumentValidationConfiguration
{
    public int Id { get; set; }
    public DocumentType DocumentTypeId { get; set; }
    public DocumentStatus DocumentStatusId { get; set; }
    public string ValidationName { get; set; }
    public string? ValidationDescription { get; set; }
    public bool IsEnabled { get; set; }
}