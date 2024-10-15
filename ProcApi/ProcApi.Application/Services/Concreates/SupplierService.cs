using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Supplier.Requests;
using ProcApi.Application.DTOs.Supplier.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Domain.Models;
using ProcApi.Domain.Constants;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public SupplierService(ISupplierRepository supplierRepository,
        IStringLocalizer<SharedResource> localizer,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _supplierRepository = supplierRepository;
        _localizer = localizer;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<SupplierResponse> GetSupplierAsync(int id)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);

        if (supplier is null)
            throw new ValidationException(_localizer[LocalizationKeys.SUPPLIER_NOT_FOUND]);

        return _mapper.Map<SupplierResponse>(supplier);
    }

    public async Task<IEnumerable<SupplierResponse>> GetAllSupplierAsync(PaginationModel pagination)
    {
        var materialsPaginated = await _supplierRepository.GetAllPaginated(pagination);

        _httpContextAccessor.HttpContext!.Response.Headers.Append(HeaderKeys.XPagination, materialsPaginated.ToString());

        return _mapper.Map<IEnumerable<SupplierResponse>>(materialsPaginated.ResultSet);
    }

    public async Task<SupplierResponse> CreateSupplierAsync(CreateSupplierRequest request)
    {
        await ValidateCreateSupplierAsync(request);

        var supplier = _mapper.Map<Supplier>(request);

        await _supplierRepository.InsertAsync(supplier);

        return _mapper.Map<SupplierResponse>(supplier);
    }

    public async Task<SupplierResponse> UpdateSupplierAsync(UpdateSupplierRequest dto)
    {
        var supplier = await _supplierRepository.GetByIdAsync(dto.Id);

        if (supplier is null)
            throw new ValidationException(_localizer[LocalizationKeys.SUPPLIER_NOT_FOUND]);

        await ValidateUpdateSupplierAsync(dto);

        _mapper.Map(dto, supplier);

        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<SupplierResponse>(supplier);
    }

    public async Task<bool> ActivateSupplier(int id, bool isActive)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);

        if (supplier is null)
            throw new ValidationException(_localizer[LocalizationKeys.SUPPLIER_NOT_FOUND]);

        supplier.IsActive = isActive;

        await _unitOfWork.SaveChangesAsync();

        return isActive;
    }

    private async Task ValidateCreateSupplierAsync(CreateSupplierRequest dto)
    {
        var supplier = await _supplierRepository.GetSupplierByNameAndTaxIdAsync(dto.Name, dto.TaxId);

        if (supplier is null)
            return;

        if (dto.Name == supplier.Name)
            throw new ValidationException(_localizer[LocalizationKeys.SUPPLIER_NAME_ALREADY_EXISTS]);

        if (dto.TaxId == supplier.TaxId)
            throw new ValidationException(_localizer[LocalizationKeys.SUPPLIER_TAX_ID_ALREADY_EXISTS]);
    }

    private async Task ValidateUpdateSupplierAsync(UpdateSupplierRequest dto)
    {
        var supplier =
            await _supplierRepository.GetSupplierExceptCurrentByNameAndTaxIdAsync(dto.Id, dto.Name, dto.TaxId);

        if (supplier is null)
            return;

        if (dto.Name == supplier.Name)
            throw new ValidationException(_localizer[LocalizationKeys.SUPPLIER_NAME_ALREADY_EXISTS]);

        if (dto.TaxId == supplier.TaxId)
            throw new ValidationException(_localizer[LocalizationKeys.SUPPLIER_TAX_ID_ALREADY_EXISTS]);
    }
}