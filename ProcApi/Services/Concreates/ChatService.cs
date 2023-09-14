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
        private readonly IGroupRepository _groupRepository;
        private readonly IChatUserRepository _chatUserRepository;
        private readonly IConnectedUsersService _connectedUsersService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ChatService(IUserRepository userRepository,
            IChatUserRepository chatUserRepository,
            IConnectedUsersService connectedUsersService,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper,
            IUnitOfWork unitOfWork, IGroupRepository groupRepository)
        {
            _userRepository = userRepository;
            _chatUserRepository = chatUserRepository;
            _connectedUsersService = connectedUsersService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _groupRepository = groupRepository;
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
            var tasks = new List<Task>();
            var userTask = _chatUserRepository.GetAllWithLastMessageByUserIdAsync(userId);
            var groupTask = _groupRepository.GetAllWithLastMessageByUserId(userId);

            await Task.WhenAll(userTask, groupTask);

            var chats = new List<ChatResponseDto>();

            chats.AddRange(_mapper.Map<IEnumerable<ChatResponseDto>>(userTask.Result));
            chats.AddRange(_mapper.Map<IEnumerable<ChatResponseDto>>(groupTask.Result));

            return chats;
        }
    }
}