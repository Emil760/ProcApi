﻿namespace ProcApi.Application.DTOs.Base;

public class DropDownDto<T>
{
    public T Key { get; set; }
    public string Value { get; set; }
}