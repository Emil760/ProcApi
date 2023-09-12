using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Chat.Request;
using ProcApi.DTOs.Chat.Responses;
using ProcApi.DTOs.Chat.Signals;
using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class ChatMessageService : IChatMessageService
{
    private readonly IHubContext<ChatHub, IChatClient> _chatHub;
    private readonly IChatService _chatService;
    private readonly IConnectedUsersService _connectedUsersService;
    private readonly IChatMessageRepository _chatMessageRepository;
    private readonly IChatRepository _chatRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ChatMessageService(IHubContext<ChatHub, IChatClient> chatHub,
        IChatService chatService,
        IConnectedUsersService connectedUsersService,
        IChatMessageRepository chatMessageRepository,
        IChatRepository chatRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _chatHub = chatHub;
        _chatService = chatService;
        _connectedUsersService = connectedUsersService;
        _chatMessageRepository = chatMessageRepository;
        _chatRepository = chatRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task SendMessageToUserAsync(int senderUserId, SendChatUserMessageRequestDto dto)
    {
        var userIds = new[] { senderUserId, dto.ReceiverUserId };

        var chat = await _chatRepository.FindWithChatUsersByAllUserIdsAsync(userIds);

        if (chat is null)
            chat = await _chatService.CreateChatBetweenUsersAsync(userIds);

        SaveMessage(chat, senderUserId, dto.ReceiverUserId, dto.Message);

        await _unitOfWork.SaveChangesAsync();

        SendSignalMessageAsync(chat, senderUserId, dto.ReceiverUserId, dto.Message);
    }

    private void SaveMessage(Chat chat, int senderUserId, int receiverUserId, string message)
    {
        var chatMessage = new ChatMessage()
        {
            ChatId = chat.Id,
            Message = message,
            SenderId = senderUserId,
            ReceivedInfos = new List<ReceivedInfo>()
            {
                new()
                {
                    ReceiverId = receiverUserId,
                    IsRead = false,
                    ReadTime = null
                }
            }
        };

        _chatMessageRepository.Insert(chatMessage);
    }

    private async Task SendSignalMessageAsync(Chat chat, int senderUserId, int receiverUserId, string message)
    {
        var connectionIds = await _connectedUsersService.GetConnectionsAsync(receiverUserId);

        var sendMessage = new SendMessageSignalDto()
        {
            ChatId = chat.Id,
            SenderId = senderUserId,
            Message = message
        };

        foreach (var connectionId in connectionIds)
        {
            await _chatHub.Clients.Client(connectionId)
                .SendUserMessageAsync(sendMessage);
        }
    }

    public async Task<MarkAdReadResponseDto> MarkAsReadAsync(int messageId, int receiverId)
    {
        var chatMessage = await _chatMessageRepository.GetWithChatUsersByIdAsync(messageId);

        if (chatMessage is null)
            throw new Exception("Message not found");

        var receiverInfo = chatMessage.ReceivedInfos.Single(ri => ri.ReceiverId == receiverId);
        receiverInfo.IsRead = true;
        receiverInfo.ReadTime = DateTime.Now;

        await _chatMessageRepository.InsertAsync(chatMessage);

        SignalMarkAsReadAsync(receiverId, receiverInfo, chatMessage);

        return _mapper.Map<MarkAdReadResponseDto>((chatMessage, receiverInfo));
    }

    private async Task SignalMarkAsReadAsync(int receiverId, ReceivedInfo receivedInfo, ChatMessage chatMessage)
    {
        var userIds = chatMessage.Chat.ChatUsers
            .Where(cu => cu.UserId != receiverId)
            .Select(cu => cu.UserId);

        var connectionIds = await _connectedUsersService.GetConnectionsAsync(userIds);

        foreach (var connectionId in connectionIds)
        {
            var markAsReadSignalDto = _mapper.Map<MarkAsReadSignalDto>((receiverId, receivedInfo, chatMessage));
            await _chatHub.Clients.Client(connectionId)
                .MarkAsReadAsync(markAsReadSignalDto);
        }
    }
}