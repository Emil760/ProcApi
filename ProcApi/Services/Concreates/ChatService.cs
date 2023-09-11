using AutoMapper;
using ProcApi.Constants;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Base;
using ProcApi.DTOs.Chat.Responses;
using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates
{
    public class ChatService : IChatService
    {
        private readonly IUserRepository _userRepository;
        private readonly IChatUserRepository _chatUserRepository;
        private readonly IChatRepository _chatRepository;
        private readonly IConnectedUsersService _connectedUsersService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ChatService(IUserRepository userRepository,
            IChatUserRepository chatUserRepository,
            IChatRepository chatRepository,
            IConnectedUsersService connectedUsersService,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _chatUserRepository = chatUserRepository;
            _chatRepository = chatRepository;
            _connectedUsersService = connectedUsersService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task ConnectAsync(int userId, string connectionId)
        {
            await _connectedUsersService.AddUserAsync(userId, connectionId);
        }

        public async Task<Chat> CreateChatBetweenUsersAsync(IEnumerable<int> userIds)
        {
            var chat = new Chat()
            {
                ChatType = ChatType.Contact
            };

            foreach (var userId in userIds)
            {
                var userChat = new ChatUser()
                {
                    Chat = chat,
                    UserId = userId
                };

                _chatUserRepository.Insert(userChat);
            }

            await _unitOfWork.SaveChangesAsync();
            return chat;
        }

        public async Task<IEnumerable<ChatUserResponseDto>> GetUsersAsync(PaginationRequestDto dto)
        {
            var usersPaginated = await _userRepository.GetAllPaginated(dto);
            
            _httpContextAccessor.HttpContext.Response.Headers.Add(HeaderKeys.XPagination, usersPaginated.ToString());

            return _mapper.Map<IEnumerable<ChatUserResponseDto>>(usersPaginated.ResultSet);
        }

        public async Task<IEnumerable<ChatResponseDto>> GetChatsAsync(int userId)
        {
            var chats = await _chatRepository.GetChatsByUserIdAsync(userId);

            return _mapper.Map<IEnumerable<ChatResponseDto>>(chats);
        }
    }
}