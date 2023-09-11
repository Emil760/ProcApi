using ProcApi.Data.ProcDatabase.Enums;
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

        // CreateMap<Chat, ChatResponseDto>()
        //     .ForMember(dest => dest.ChatId, otp => otp.MapFrom(src => src.Id))
        //     .ForMember(dest => dest.Name,
        //         otp => otp.MapFrom(src =>
        //             src.GroupId == null ? src.ChatUsers.Single().User.FirstName : src.Group!.Name))
        //     .ForMember(dest => dest.ChatType,
        //         opt => opt.MapFrom(src => src.GroupId == null ? ChatType.Contact : ChatType.Group));
    }
}