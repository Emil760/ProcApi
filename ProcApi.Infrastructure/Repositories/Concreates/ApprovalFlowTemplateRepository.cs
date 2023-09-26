using Microsoft.EntityFrameworkCore;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Infrastructure.Data;
using ProcApi.Infrastructure.Repositories.Abstracts;

namespace ProcApi.Infrastructure.Repositories.Concreates
{
    public class ApprovalFlowTemplateRepository : GenericRepository<ApprovalFlowTemplate>, IApprovalFlowTemplateRepository
    {
        public ApprovalFlowTemplateRepository(ProcDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ApprovalFlowTemplate>> GetInitialByDocumentType(DocumentType type)
        {
            return await _context.ApprovalFlowTemplates
                .Where(aft => aft.DocumentTypeId == type
                              && aft.IsInitial)
                .OrderBy(aft => aft.Order)
                .ToListAsync();
        }

        public async Task<IEnumerable<ApprovalFlowTemplate>> GetInitialWithUserByDocumentType(DocumentType type)
        {
            return await _context.ApprovalFlowTemplates
                .Include(aft => aft.User)
                .Where(aft => aft.DocumentTypeId == type
                              && aft.IsInitial)
                .OrderBy(aft => aft.Order)
                .ToListAsync();
        }
    }
}

