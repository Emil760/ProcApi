﻿using ProcApi.Application.DTOs.Chat.Responses;
using ProcApi.Application.DTOs.Chat.Signals;
using ProcApi.Domain.Entities;

namespace ProcApi.Application.Mappers;

public class ChatProfile : CommonProfile
{
    public ChatProfile()
    {
        CreateMap<User, ChatUserResponse>();

        CreateMap<ChatMessage, SendMessageSignalDto>();

        CreateMap<(ChatMessage ChatMessage, ReceivedInfo ReceivedInfo), MarkAdReadResponse>()
            .ForMember(dest => dest.MessageId, opt => opt.MapFrom(src => src.ChatMessage.Id))
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.ReceivedInfo.ReceiverId))
            .ForMember(dest => dest.ReadTime, opt => opt.MapFrom(src => src.ReceivedInfo.ReadTime))
            .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => src.ReceivedInfo.IsRead));

        CreateMap<(ReceivedInfo ReceivedInfo, ChatMessage ChatMessage), MarkAsReadSignalDto>()
            .ForMember(dest => dest.ReceiverId, opt => opt.MapFrom(src => src.ReceivedInfo.ReceiverId))
            .ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.ChatMessage.ChatId))
            .ForMember(dest => dest.MessageId, opt => opt.MapFrom(src => src.ChatMessage.Id))
            .ForMember(dest => dest.ReadTime, opt => opt.MapFrom(src => src.ReceivedInfo.ReadTime))
            .ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => src.ReceivedInfo.IsRead));

        CreateMap<GroupUser, GroupUserResponse>()
            .ForMember(dest => dest.ChatUserId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ChatUser.UserId))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.ChatUser.User.FirstName))
            .ForMember(dest => dest.ChatRole, opt => opt.MapFrom(src => src.ChatRole));

        CreateMap<Group, CreatedGroupResponse>()
            .ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.GroupUsers));

        CreateMap<Group, GroupCreatedSignalDto>()
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.GroupUsers));

        CreateMap<ChatUser, ChatResponse>()
            .ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.ChatId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastMessage, opt => opt.MapFrom(src =>
                src.Chat.ChatMessages.FirstOrDefault() == null
                    ? null
                    : src.Chat.ChatMessages.FirstOrDefault()))
            .ForMember(dest => dest.ChatType, opt => opt.MapFrom(src => src.Chat.ChatTypeId));

        CreateMap<Group, ChatResponse>()
            .ForMember(dest => dest.ChatId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LastMessage, opt => opt.MapFrom(src =>
                src.Chat.ChatMessages.FirstOrDefault() == null
                    ? null
                    : src.Chat.ChatMessages.FirstOrDefault()))
            .ForMember(dest => dest.ChatType, opt => opt.MapFrom(src => src.Chat.ChatTypeId));
    }
}