using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities
{
    public class DashboardSection : IEntity<int>
    {
        public int Id { get; set; }
        public int UserDashboardId { get; set; }
        public UserDashboard UserDashboard { get; set; }
        public int DocumentTypeStatusId { get; set; }
        public DocumentTypeStatus DocumentTypeStatus { get; set; }
    }
}
