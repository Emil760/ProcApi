using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.DocumentPattern.Base
{
    public class DocumentNumberSectionBaseDto
    {
        public int DocumentNumberPatternId { get; set; }
        public DocumentNumberSectionType SectionType { get; set; }
        public short Order { get; set; }
        public string Delimiter { get; set; }
        public string Format { get; set; }
        public string Value { get; set; }
    }
}
