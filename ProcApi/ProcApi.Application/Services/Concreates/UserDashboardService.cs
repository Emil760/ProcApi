using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Dashboard.Requests;
using ProcApi.Application.DTOs.Dashboard.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates
{
    public class UserDashboardService : IUserDashboardService
    {
        private readonly IUserDashboardRepository _userDashboardRepository;
        private readonly IDashboardSectionRepository _dashboardSectionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _localizer;


        public UserDashboardService(IUserDashboardRepository userDashboardRepository,
            IDashboardSectionRepository dashboardSectionRepository,
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IStringLocalizer<SharedResource> localizer)
        {
            _userDashboardRepository = userDashboardRepository;
            _dashboardSectionRepository = dashboardSectionRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<int> CreateDashboardAsync(int userId, AddDashboardRequest dto)
        {
            if (!await _userRepository.ExistsByIdAsync(userId))
                throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND]);

            var entity = _mapper.Map<UserDashboard>(dto);

            await _userDashboardRepository.InsertAsync(entity);

            return entity.Id;
        }

        public async Task<IEnumerable<DashboardResponse>> GetAllByUserIdAsync(int userId)
        {
            var entities = await _userDashboardRepository.GetByUserIdAsync(userId);

            return _mapper.Map<IEnumerable<DashboardResponse>>(entities);
        }

        public async Task ManageSectionAsync(ManageSectionRequest dto)
        {
            var userDashboard = await _userDashboardRepository.GetWithSectionsAsync(dto.UserDashboardId);
            if (userDashboard is null)
                throw new NotFoundException(_localizer[LocalizationKeys.USER_DASHBOARD_NOT_FOUND]);

            AddSections(userDashboard, dto.DocumentStatuses);

            RemoveSections(userDashboard, dto.DocumentStatuses);

            await _unitOfWork.SaveChangesAsync();
        }

        public void AddSections(UserDashboard userDashboard, IEnumerable<DocumentStatus> requestStatuses)
        {
            var sectionsToAdd = requestStatuses.Where(x => !userDashboard.Sections
                                                           .Select(s => s.DocumentStatus)
                                                           .Contains(x));

            foreach (var sectionToAdd in sectionsToAdd)
            {
                userDashboard.Sections.Add(new DashboardSection()
                {
                    DocumentStatus = sectionToAdd
                });
            }
        }

        public void RemoveSections(UserDashboard userDashboard, IEnumerable<DocumentStatus> requestStatuses)
        {
            var sectionsToRemove = userDashboard.Sections.Where(s => !requestStatuses.Contains(s.DocumentStatus));

            _dashboardSectionRepository.Delete(sectionsToRemove);
        }
    }
}
