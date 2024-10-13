using ProcApi.Domain.Enums;
using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class DocumentNumberSection : IEntity<int>
{
    public int Id { get; set; }
    public int DocumentNumberPatternId { get; set; }
    public DocumentNumberPattern DocumentNumberPattern { get; set; }
    public DocumentNumberSectionType SectionType { get; set; }
    public short Order { get; set; }
    public string Delimiter { get; set; }
    public string Format { get; set; }
    public string Value { get; set; }
}
