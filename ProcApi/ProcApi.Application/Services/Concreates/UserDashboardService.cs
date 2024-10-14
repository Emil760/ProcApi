using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Dashboard.Requests;
using ProcApi.Application.DTOs.Dashboard.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
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
        private readonly IDocumentTypeStatusRepository _documentTypeStatusRepository;
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

            var allDocumentTypeStatuses = await _documentTypeStatusRepository.GetAllAsync();

            AddSections(userDashboard, allDocumentTypeStatuses, dto.DocumentTypeStatusIds);

            RemoveSections(userDashboard, dto.DocumentTypeStatusIds);

            await _unitOfWork.SaveChangesAsync();
        }

        private void AddSections(UserDashboard userDashboard,
            IEnumerable<DocumentTypeStatus> documentTypeStatuses,
            IEnumerable<int> requestDocumentTypeStatusIds)
        {
            var sectionsToAdd = requestDocumentTypeStatusIds.Where(x => !userDashboard.Sections
                                                           .Select(s => s.Id)
                                                           .Contains(x));

            foreach (var sectionToAdd in sectionsToAdd)
            {
                var documentTypeStatus = documentTypeStatuses.FirstOrDefault(x => x.Id == sectionToAdd);

                if (documentTypeStatus is null)
                    continue;

                userDashboard.Sections.Add(new DashboardSection()
                {
                    UserDashboard = userDashboard,
                    DocumentTypeStatus = documentTypeStatus
                });
            }
        }

        private void RemoveSections(UserDashboard userDashboard,
            IEnumerable<int> requestDocumentTypeStatusIds)
        {
            var sectionsToRemove = userDashboard.Sections.Where(s => !requestDocumentTypeStatusIds.Contains(s.DocumentTypeStatusId));

            _dashboardSectionRepository.Delete(sectionsToRemove);
        }

        public async Task<IEnumerable<int>> GetSelectedSectionsAsync(int userDashboardId)
        {
            return await _dashboardSectionRepository.GetIdsByDashboardIdAsync(userDashboardId);
        }
    }
}
