using ProcApi.Application.DTOs.DocumentPattern.Base;
using ProcApi.Domain.Utility;

namespace ProcApi.Application.DTOs.DocumentPattern.Responses
{
    public class DocumentNumberSectionReponse : DocumentNumberSectionBaseDto
    {
        public int Id { get; set; }
        public string SectionTypeName { get => SectionType.GetDescription(); }
    }
}
