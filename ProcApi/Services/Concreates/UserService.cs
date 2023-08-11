using AutoMapper;
using ProcApi.Comparers;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.User;
using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.UnitOfWork;
using ProcApi.Services.Abstracts;
using ProcApi.ViewModels.User;

namespace ProcApi.Services.Concreates
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserViewModel> AddUserAsync(AddUserDto dto)
        {
            var user = _mapper.Map<User>(dto);

            _userRepository.Insert(user);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            users = users.OrderByDescending(u => u.Gender, new GenderComparer());

            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }
    }
}
