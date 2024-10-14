using ProcApi.Domain.Enums;
using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities
{
    public class DocumentTypeStatus : IEntity<int>
    {
        public int Id { get; set; }
        public DocumentType DocumentType { get; set; }
        public DocumentStatus DocumentStatus { get; set; }

        public ICollection<DashboardSection> DashboardSections { get; set; }
    }
}
