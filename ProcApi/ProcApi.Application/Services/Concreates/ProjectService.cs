using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.Project.Requests;
using ProcApi.Application.DTOs.Project.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IProjectRepository projectRepository,
            IStringLocalizer<SharedResource> localizer,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _projectRepository = projectRepository;
            _localizer = localizer;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProjectResponseDto> CreateProjectAsync(CreateProjectRequestDto dto)
        {
            var isExists = await _projectRepository.ExistsByNameAsync(dto.Name);
            if (isExists)
                throw new ValidationException(_localizer[LocalizationKeys.PROJECT_NAME_ALREADY_EXISTS]);

            var project = _mapper.Map<CreateProjectRequestDto, Project>(dto);
            await _projectRepository.InsertAsync(project);
            return _mapper.Map<ProjectResponseDto>(project);
        }

        public async Task<IEnumerable<ProjectResponseDto>> GetProjectsAsync()
        {
            var data = await _projectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectResponseDto>>(data);
        }

        public async Task<ProjectResponseDto> GetProjectAsync(int id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project is null)
                throw new NotFoundException(_localizer[LocalizationKeys.PROJECT_NOT_FOUND]);

            return _mapper.Map<ProjectResponseDto>(project);
        }

        public async Task<IEnumerable<DropDownDto<int>>> GetProjectsForDropDownAsync()
        {
            var data = await _projectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DropDownDto<int>>>(data);
        }

        public async Task<ProjectResponseDto> UpdateProjectAsync(UpdateProjectRequestDto dto)
        {
            var project = await _projectRepository.GetByIdAsync(dto.Id);
            if (project is null)
                throw new NotFoundException(_localizer[LocalizationKeys.PROJECT_NOT_FOUND]);

            var exists = await _projectRepository.ExistsByNameExceptCurrentAsync(dto.Id, dto.Name);
            if (exists)
                throw new ValidationException(_localizer[LocalizationKeys.PROJECT_NAME_ALREADY_EXISTS]);

            _mapper.Map(dto, project);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProjectResponseDto>(project);
        }
    }
}
