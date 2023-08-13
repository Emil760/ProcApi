﻿namespace ProcApi.Data.ProcDatabase.Models;

public class FeatureConfiguration
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsEnabled { get; set; }
}