using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs;
using ProcApi.Application.DTOs.Project.Requests;
using ProcApi.Application.DTOs.Project.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates
{
    public class ProjectService : IProjectSercive
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IStringLocalizer<SharedResource> _localizer;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository,
            IStringLocalizer<SharedResource> localizer,
            IMapper mapper)
        {
            _projectRepository = projectRepository;
            _localizer = localizer;
            _mapper = mapper;
        }

        //TODO localization
        public async Task<ProjectResponseDto> CreateProjectAsync(CreateProjectRequestDto dto)
        {
            var isExists = await _projectRepository.ExistsByNameAsync(dto.Name);
            if (isExists)
                throw new ValidationException(_localizer[""]);

            var project = _mapper.Map<CreateProjectRequestDto, Project>(dto);
            await _projectRepository.InsertAsync(project);
            return _mapper.Map<ProjectResponseDto>(project);
        }

        public async Task<IEnumerable<ProjectResponseDto>> GetProjectsAsync()
        {
            var data = await _projectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectResponseDto>>(data);
        }

        public async Task<IEnumerable<DropDownDto<int>>> GetProjectsForDropDownAsync()
        {
            var data = await _projectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DropDownDto<int>>>(data);
        }
    }
}
