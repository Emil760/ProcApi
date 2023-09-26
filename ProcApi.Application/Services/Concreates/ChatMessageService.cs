using AutoMapper;
using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Chat.Request;
using ProcApi.Application.DTOs.Chat.Responses;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class ChatMessageService : IChatMessageService
{
    private readonly IChatMessageSignalService _chatMessageSignalService;
    private readonly IChatService _chatService;
    private readonly IChatMessageRepository _chatMessageRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChatMessageService(IChatMessageSignalService chatMessageSignalService,
        IChatService chatService,
        IChatMessageRepository chatMessageRepository,
        IChatRepository chatRepository,
        IStringLocalizer<SharedResource> localizer,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _chatService = chatService;
        _chatMessageRepository = chatMessageRepository;
        _chatRepository = chatRepository;
        _chatMessageSignalService = chatMessageSignalService;
        _localizer = localizer;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task SendMessageToUserAsync(int senderUserId, SendChatUserMessageRequestDto dto)
    {
        var userIds = new[] { senderUserId, dto.ReceiverUserId };

        var chat = await _chatRepository.FindWithChatUsersByAllUserIdsAsync(userIds);

        if (chat is null)
            chat = await _chatService.CreateChatBetweenUsersAsync(userIds);

        var chatMessage = CreateMessage(chat, senderUserId, dto.Message);

        _chatMessageRepository.Insert(chatMessage);

        await _unitOfWork.SaveChangesAsync();

        _chatMessageSignalService.SendUserSignalMessageAsync(chatMessage, new List<int> { dto.ReceiverUserId });
    }

    public async Task SendMessageToGroupAsync(int senderUserId, SendGroupMessageRequestDto dto)
    {
        var chat = await _chatRepository.FindWithChatUsersExceptCurrUserByChatIdAsync(dto.ChatId, senderUserId);

        if (chat is null)
            throw new ValidationException(_localizer["ChatNotFound"]);

        var chatMessage = CreateMessage(chat, senderUserId, dto.Message);

        _chatMessageRepository.Insert(chatMessage);

        await _unitOfWork.SaveChangesAsync();

        var userIds = chat.ChatUsers.Select(cu => cu.UserId);

        _chatMessageSignalService.SendUserSignalMessageAsync(chatMessage, userIds);
    }

    private ChatMessage CreateMessage(Chat chat, int senderUserId, string message)
    {
        return new ChatMessage()
        {
            ChatId = chat.Id,
            Message = message,
            SendTime = DateTime.Now,
            SenderId = senderUserId,
        };
    }

    public async Task<MarkAdReadResponseDto?> MarkAsReadAsync(int messageId, int receiverId)
    {
        var chatMessage =
            await _chatMessageRepository.GetWithChatUsersExceptCurrentUserByIdAsync(messageId, receiverId);

        if (chatMessage is null)
            throw new Exception("Message not found");

        ReceivedInfo? receivedInfo = null;

        if (chatMessage.ReceivedInfos is not null)
            receivedInfo = chatMessage.ReceivedInfos.SingleOrDefault(ri => ri.ReceiverId == receiverId);
        else
            chatMessage.ReceivedInfos = new List<ReceivedInfo>();

        if (receivedInfo is not null)
            return null;

        var receiverInfo = new ReceivedInfo()
        {
            ReceiverId = receiverId,
            IsRead = true,
            ReadTime = DateTime.Now
        };

        chatMessage.ReceivedInfos.Add(receiverInfo);

        await _chatMessageRepository.InsertAsync(chatMessage);

        _chatMessageSignalService.SignalMarkAsReadAsync(receiverInfo, chatMessage);

        return _mapper.Map<MarkAdReadResponseDto>((chatMessage, receiverInfo));
    }
}