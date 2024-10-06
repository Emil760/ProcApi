using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class Category : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public ICollection<Material> Materials { get; set; }
}