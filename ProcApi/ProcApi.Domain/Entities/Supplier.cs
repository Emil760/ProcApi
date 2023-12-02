namespace ProcApi.Domain.Entities;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string TaxId { get; set; }
    public bool IsActive { get; set; }
}