using AutoMapper;
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
        private IUserRepository _userRepository;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserViewModel> AddUser(AddUserDTO dto)
        {
            var user = _mapper.Map<User>(dto);

            _userRepository.Insert(user);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserViewModel>>(users);
        }
    }
}
