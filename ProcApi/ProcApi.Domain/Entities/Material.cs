using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class Material : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}