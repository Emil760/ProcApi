using ProcApi.Application.DTOs.PurchaseRequestDocument.Requests;
using ProcApi.Application.DTOs.PurchaseRequestDocument.Response;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers
{
    public class PurchaseRequestProfile : CommonProfile
    {
        public PurchaseRequestProfile()
        {
            CreateMap<CreatePRItemRequestDto, PurchaseRequestDocumentItem>();

            CreateMap<CreatePRRequestDto, PurchaseRequestDocument>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
                .ForMember(dest => dest.RequestedForDepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

            CreateMap<UpdatePRRequestDto, PurchaseRequestDocument>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
                .ForMember(dest => dest.RequestedForDepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.Items, opt => opt.Ignore());

            CreateMap<PurchaseRequestDocument, PRResponseDto>()
                .ForMember(dest => dest.BaseDocumentDto, opt => opt.MapFrom(src => src.Document))
                .ForMember(dest => dest.MembersDto, opt => opt.MapFrom(src => src.Document.Actions))
                .ForMember(dest => dest.ItemsDto, opt => opt.MapFrom(src => src.Items));

            CreateMap<PurchaseRequestDocument, SavePRResponseDto>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.RequestedForDepartmentId))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}