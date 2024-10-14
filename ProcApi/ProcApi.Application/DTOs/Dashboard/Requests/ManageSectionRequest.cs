using ProcApi.Domain.Enums;

namespace ProcApi.Application.DTOs.Dashboard.Requests
{
    public class ManageSectionRequest
    {
        public int UserDashboardId { get; set; }
        public IEnumerable<int> DocumentTypeStatusIds { get; set; }
    }
}
