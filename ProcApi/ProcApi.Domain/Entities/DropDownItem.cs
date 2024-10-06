using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class DropDownItem : IEntity<int>
{
    public int Id { get; set; }
    public int DropDownSourceId { get; set; }
    public DropDownSource DropDownSource { get; set; }
    public string Value { get; set; }
}