using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Delegation.Requests;
using ProcApi.Application.DTOs.Delegation.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Models;
using ProcApi.Domain.Constants;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class DelegationService : IDelegationService
{
    private readonly IUserRepository _userRepository;
    private readonly IDelegationRepository _delegationRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IMapper _mapper;

    public DelegationService(IUserRepository userRepository,
        IDelegationRepository delegationRepository,
        IStringLocalizer<SharedResource> localizer,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _delegationRepository = delegationRepository;
        _localizer = localizer;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }

    public async Task CreateDelegationAsync(CreateDelegationRequest dto)
    {
        var users = await _userRepository.GetByIdsAsync(dto.FromUserId, dto.ToUserId);

        if (users.Count() != 2)
            throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND]);

        var delegation = _mapper.Map<Delegation>(dto);

        await _delegationRepository.InsertAsync(delegation);
    }

    public async Task<IEnumerable<DelegationResponse>> GetDelegations(PaginationModel model)
    {
        var delegationPaginated = await _delegationRepository.GetAllPaginated(model);
        
        _httpContextAccessor.HttpContext!.Response.Headers.Add(HeaderKeys.XPagination, delegationPaginated.ToString());

        return _mapper.Map<IEnumerable<DelegationResponse>>(delegationPaginated.ResultSet);
    }
}