using AutoMapper;
using ProcApi.Application.DTOs;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;

namespace ProcApi.Application.Services.Concreates
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DashboardService(IDashboardRepository dashboardRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dashboardRepository = dashboardRepository;
        }

        public async Task<IEnumerable<DropDownDto<int>>> GetDashboardsForDropDownAsync()
        {
            var data = await _dashboardRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DropDownDto<int>>>(data);
        }
    }
}
