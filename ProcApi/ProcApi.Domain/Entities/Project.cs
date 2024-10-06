using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class Project : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Budget { get; set; }
}