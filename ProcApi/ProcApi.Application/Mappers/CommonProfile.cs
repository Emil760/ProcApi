using AutoMapper;
using ProcApi.Application.DTOs.Documents.Base;
using ProcApi.Application.DTOs.Documents.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class CommonProfile : Profile
{
    public CommonProfile()
    {
        CreateMap<Document, BaseDocumentDto>()
            .ForMember(dest => dest.DocumentId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(src => src.Number))
            .ForMember(dest => dest.DocumentStatus, opt => opt.MapFrom(src => src.DocumentStatusId))
            .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentTypeId))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn));

        CreateMap<Document, DocumentResponseDto>()
            .ForMember(dest => dest.DocumentId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(src => src.Number))
            .ForMember(dest => dest.DocumentStatus, opt => opt.MapFrom(src => src.DocumentStatusId))
            .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentTypeId))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
            .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Actions));

        CreateMap<DocumentAction, DocumentMemberResponseDto>()
            .ForMember(dest => dest.AssignerName, opt => opt.MapFrom(src => src.Assigner.FirstName))
            .ForMember(dest => dest.PerformerName, opt => opt.MapFrom(src => src.Performer.FirstName))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ForMember(dest => dest.ActionAssigned, opt => opt.MapFrom(src => src.ActionAssigned))
            .ForMember(dest => dest.IsAssigned, opt => opt.MapFrom(src => src.IsAssigned))
            .ForMember(dest => dest.ActionPerformed, opt => opt.MapFrom(src => src.ActionPerformed))
            .ForMember(dest => dest.IsPerformed, opt => opt.MapFrom(src => src.IsPerformed))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order));
    }
}