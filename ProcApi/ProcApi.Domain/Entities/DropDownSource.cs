namespace ProcApi.Domain.Entities;

public class DropDownSource
{
    public int Id { get; set; }
    public string Key { get; set; }
    public ICollection<DropDownItem> Items { get; set; }
}