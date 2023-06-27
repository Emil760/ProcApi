using ProcApi.DTOs.User;
using ProcApi.ViewModels.User;

namespace ProcApi.Services.Abstracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsers();
        Task<UserViewModel> AddUser(AddUserDTO dto); 
    }
}
