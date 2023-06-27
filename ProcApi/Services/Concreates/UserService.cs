using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;
using ProcApi.ViewModel;

namespace ProcApi.Services.Concreates
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        //private IMapper mapper;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            //this.mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> GetUsers()
        {
            var users = await userRepository.GetUsers();

            return null;
            //return mapper.Map<IEnumerable<UserViewModel>>(users);
        }
    }
}
