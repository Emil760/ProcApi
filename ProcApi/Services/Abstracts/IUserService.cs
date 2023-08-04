using ProcApi.DTOs.User;
using ProcApi.ViewModels.User;

namespace ProcApi.Services.Abstracts
{
    public interface IUserService
    {
        Task<UserViewModel> GetByIdAsync(int id);
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> AddUserAsync(AddUserDTO dto); 
    }
}
