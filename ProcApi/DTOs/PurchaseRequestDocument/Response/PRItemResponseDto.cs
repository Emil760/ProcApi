﻿namespace ProcApi.DTOs.PurchaseRequestDocument.Response;

public class PRItemResponseDto
{
    public int Id { get; set; }
    public int MaterialId { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public int UnitOfMeasureId { get; set; }
}