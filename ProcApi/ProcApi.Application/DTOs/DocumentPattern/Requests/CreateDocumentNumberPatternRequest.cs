using ProcApi.Application.DTOs.DocumentPattern.Base;
using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.DocumentPattern.Requests
{
    public class CreateDocumentNumberPatternRequest
    {
        public DocumentType DocumentType { get; set; }
        public string Name { get; set; }
    }
}
