using ProcApi.Application.DTOs.Delegation.Requests;
using ProcApi.Application.DTOs.Delegation.Responses;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Abstracts;

public interface IDelegationService
{
    Task CreateDelegationAsync(CreateDelegationRequest dto);
    Task<IEnumerable<DelegationResponse>> GetDelegations(PaginationModel model);
}