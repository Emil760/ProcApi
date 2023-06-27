using ProcApi.ViewModel;

namespace ProcApi.Services.Abstracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetUsers();
    }
}
