using ProcApi.Application.DTOs.Delegation.Requests;
using ProcApi.Application.DTOs.Delegation.Responses;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class DelegationProfile : CommonProfile
{
    public DelegationProfile()
    {
        CreateMap<CreateDelegationRequest, Delegation>();

        CreateMap<Delegation, DelegationResponse>()
            .ForMember(dest => dest.FromUserName, opt => opt.MapFrom(src => src.FromUser.FirstName))
            .ForMember(dest => dest.ToUserName, opt => opt.MapFrom(src => src.ToUser.FirstName))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));
    }
}