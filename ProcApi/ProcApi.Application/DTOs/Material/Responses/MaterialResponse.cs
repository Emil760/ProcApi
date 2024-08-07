﻿using ProcApi.Application.DTOs.Material.Base;

namespace ProcApi.Application.DTOs.Material.Responses;

public class MaterialResponse : MaterialDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}