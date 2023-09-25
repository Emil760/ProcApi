using AutoMapper;
using ProcApi.DTOs.PurchaseRequestDocument.Response;
using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class PurchaseRequestDocumentItemsService : IPurchaseRequestDocumentItemsService
{
    private readonly IPurchaseRequestDocumentItemsRepository _purchaseRequestDocumentItemsRepository;
    private readonly IMapper _mapper;

    public PurchaseRequestDocumentItemsService(
        IPurchaseRequestDocumentItemsRepository purchaseRequestDocumentItemsRepository,
        IMapper mapper)
    {
        _purchaseRequestDocumentItemsRepository = purchaseRequestDocumentItemsRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PRItemResponseDto>> GetAllItemsAsync(int docId)
    {
        var items = await _purchaseRequestDocumentItemsRepository.GetAllByDocIdAsync(docId);

        return _mapper.Map<IEnumerable<PRItemResponseDto>>(items);
    }
}