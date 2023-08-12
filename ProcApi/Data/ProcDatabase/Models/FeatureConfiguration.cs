namespace ProcApi.Data.ProcDatabase.Models;

public class FeatureConfiguration
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required bool IsEnabled { get; set; }
}