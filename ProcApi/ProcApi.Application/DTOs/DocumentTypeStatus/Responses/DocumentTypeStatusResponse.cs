using ProcApi.Application.DTOs.DocumentTypeStatus.Base;
using ProcApi.Domain.Utility;

namespace ProcApi.Application.DTOs.DocumentTypeStatus.Responses
{
    public class DocumentTypeStatusResponse : DocumentTypeStatusBaseDto
    {
        public int Id { get; set; }
        public string DocumentTypeName { get => DocumentType.GetDescription(); }
        public string DocumentStatusName { get => DocumentStatus.GetDescription(); }
    }
}
