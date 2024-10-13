using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities
{
    public class UserDashboard : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string ForegroundColor { get; set; }
        public string BackgroundColor { get; set; }
        public ICollection<DashboardSection> Sections { get; set; }
    }
}
