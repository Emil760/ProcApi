using AutoMapper;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Documents;
using ProcApi.DTOs.Documents.Base;
using ProcApi.DTOs.Documents.Responses;

namespace ProcApi.Mappers;

public class CommonProfile : Profile
{
    public CommonProfile()
    {
        CreateMap<Document, BaseDocumentDto>()
            .ForMember(dest => dest.DocumentId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DocumentNumber, opt => opt.MapFrom(src => src.DocumentNumber))
            .ForMember(dest => dest.DocumentStatus, opt => opt.MapFrom(src => src.DocumentStatusId))
            .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentTypeId))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn));

        CreateMap<DocumentAction, DocumentMemberResponseDto>()
            .ForMember(dest => dest.MemberName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.ActionPerformed, opt => opt.MapFrom(src => src.ActionPerformed))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ForMember(src => src.IsPerformed, opt => opt.MapFrom(src => src.IsPerformed));
    }
}