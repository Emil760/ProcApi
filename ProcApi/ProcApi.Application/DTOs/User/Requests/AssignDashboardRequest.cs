namespace ProcApi.Application.DTOs.User.Requests
{
    public class AssignDashboardRequest
    {
        public int UserId { get; set; }
        public int DashboardId { get; set; }
    }
}
