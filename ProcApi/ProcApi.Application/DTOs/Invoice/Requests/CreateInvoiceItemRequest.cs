﻿using ProcApi.Application.DTOs.Invoice.Base;
using ProcApi.Application.Enums;

namespace ProcApi.Application.DTOs.Invoice.Requests;

public class CreateInvoiceItemRequest : InvoiceItemDto
{
    public int Id { get; set; }
    public ActionState State { get; set; }
}