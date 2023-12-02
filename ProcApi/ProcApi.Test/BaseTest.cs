using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Presentation.Configurations;

namespace TestProject.UnitTest;

public class BaseTest : IDisposable
{
    protected readonly ProcDbContext _context;
    protected readonly UnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    

    public BaseTest()
    {
        var options = new DbContextOptionsBuilder<ProcDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

        _context = new ProcDbContext(options);

        _unitOfWork = new UnitOfWork(_context);

        _mapper = MapperConfigurationExtension.Initialize();
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
    }
}