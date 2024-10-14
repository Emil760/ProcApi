using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.DocumentTypeStatus.Base
{
    public class DocumentTypeStatusBaseDto
    {
        public DocumentType DocumentType { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
    }
}
