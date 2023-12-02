namespace ProcApi.Application.Services.Abstracts;

public interface IConnectedUsersService
{
    Task AddUserAsync(int userId, string connectionId);
    Task RemoveUserAsync(int userId);
    Task<Dictionary<int, List<string>>> GetConnectedUsersAsync();
    Task<List<string>> GetConnectionsAsync(int userId);
    Task<List<string>> GetConnectionsAsync(IEnumerable<int> userId);
    Task RemoveConnectionIdAsync(string connectionId);
}