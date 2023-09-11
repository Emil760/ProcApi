﻿using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ProcApi.Utility;

public class Paginator<TEntity>
{
    private const int defaultPage = 1;
    private const int defaultPageSize = 20;

    [JsonIgnore] 
    public IEnumerable<TEntity> ResultSet { get; set; }
    public int TotalSize { get; set; }

    public static async Task<Paginator<TEntity>> FromQuery(IQueryable<TEntity> queryable, int? pageNumber,
        int? pageSize)
    {
        var paginator = new Paginator<TEntity>();

        paginator.ResultSet = await queryable
            .Skip(GetPageSize(pageSize) * (GetPageNumber(pageNumber) - 1))
            .Take(GetPageSize(pageSize))
            .ToListAsync();
        
        paginator.TotalSize = await queryable.CountAsync();
        
        return paginator;
    }

    private static int GetPageNumber(int? pageNumber)
    {
        return pageNumber ?? defaultPage;
    }

    private static int GetPageSize(int? pageSize)
    {
        return pageSize ?? defaultPageSize;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}