using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Chat.Responses;
using ProcApi.DTOs.Chat.Signals;

namespace ProcApi.Mappers;

public class ChatProfile : CommonProfile
{
    public ChatProfile()
    {
        CreateMap<User, ChatUserResponseDto>();

        CreateMap<(ChatMessage ChatMessage, ReceivedInfo ReceivedInfo), MarkAdReadResponseDto>()
            .ForMember(dest => dest.MessageId, opt => opt.MapFrom(src => src.ChatMessage.Id))
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.ReceivedInfo.ReceiverId))
            .ForMember(dest => dest.ReadTime, opt => opt.MapFrom(src => src.ReceivedInfo.ReadTime))
            .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => src.ReceivedInfo.IsRead));

        CreateMap<(int receiverId, ReceivedInfo ReceivedInfo, ChatMessage ChatMessage), MarkAsReadSignalDto>()
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.receiverId))
            .ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.ChatMessage.ChatId))
            .ForMember(dest => dest.MessageId, opt => opt.MapFrom(src => src.ChatMessage.Id))
            .ForMember(dest => dest.ReadTime, opt => opt.MapFrom(src => src.ReceivedInfo.ReadTime))
            .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => src.ReceivedInfo.IsRead));

        CreateMap<GroupUser, GroupUserResponseDto>()
            .ForMember(dest => dest.ChatUserId, opt => opt.MapFrom(src => src.ChatUserId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ChatUser.UserId))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ChatUser.User.FirstName))
            .ForMember(dest => dest.ChatRole, opt => opt.MapFrom(src => src.ChatRole));

        CreateMap<Group, CreatedGroupResponseDto>()
            .ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.ChatId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.GroupUsers));

        CreateMap<Group, GroupCreatedSignalDto>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.GroupUsers));
    }
}