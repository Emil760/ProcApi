using ProcApi.Domain.Entities;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates;

public class UnitOfMeasuresRepository : GenericRepository<UnitOfMeasure>, IUnitOfMeasureRepository
{
    public UnitOfMeasuresRepository(ProcDbContext context) : base(context)
    {
    }
}