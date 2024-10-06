using ProcApi.Domain.Enums;
using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities;

public class FeatureConfiguration : IEntity<int>
{
    public int Id { get; set; }
    public ConfigurationType ConfigurationType { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Value { get; set; }
    public bool IsEnabled { get; set; }
}