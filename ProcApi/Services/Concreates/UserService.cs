using AutoMapper;
using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;
using ProcApi.ViewModel;

namespace ProcApi.Services.Concreates
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var users = await userRepository.GetAllAsync();

            return mapper.Map<IEnumerable<UserViewModel>>(users);
        }
    }
}
