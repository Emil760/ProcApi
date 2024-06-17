namespace ProcApi.Domain.Entities;

public class AnnualProcurement
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public short Version { get; set; }
    public bool IsActive { get; set; }
}