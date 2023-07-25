using ProcApi.Data.ProcDatabase.Models;
using ProcApi.ViewModels.User;

namespace ProcApi.Caches.Abstracts
{
    public interface IUserCachedService
    {
        Task<UserViewModel> GetByIdAsync(int id);
    }
}
