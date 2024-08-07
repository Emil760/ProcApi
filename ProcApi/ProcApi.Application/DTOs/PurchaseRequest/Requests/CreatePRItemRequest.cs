﻿using ProcApi.Application.DTOs.PurchaseRequest.Base;
using ProcApi.Application.Enums;

namespace ProcApi.Application.DTOs.PurchaseRequest.Requests;

public class CreatePRItemRequest : PRItemDto
{
    public int Id { get; set; }
    public ActionState State { get; set; }
}