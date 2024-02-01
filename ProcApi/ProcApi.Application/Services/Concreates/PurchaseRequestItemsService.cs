using AutoMapper;
using ProcApi.Application.DTOs.PurchaseRequest.Response;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Application.Services.Concreates;

public class PurchaseRequestItemsService : IPurchaseRequestItemsService
{
    private readonly IPurchaseRequestItemsRepository _purchaseRequestItemsRepository;
    private readonly IMapper _mapper;

    public PurchaseRequestItemsService(
        IPurchaseRequestItemsRepository purchaseRequestItemsRepository,
        IMapper mapper)
    {
        _purchaseRequestItemsRepository = purchaseRequestItemsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PRItemResponseDto>> GetAllItemsAsync(int docId)
    {
        var items = await _purchaseRequestItemsRepository.GetAllByDocIdAsync(docId);

        return _mapper.Map<IEnumerable<PRItemResponseDto>>(items);
    }
}