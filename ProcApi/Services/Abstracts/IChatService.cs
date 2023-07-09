namespace ProcApi.Services.Abstracts
{
    public interface IChatService
    {
        Task SendBulk(int userId, string message);
    }
}
