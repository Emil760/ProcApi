using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.User;
using ProcApi.DTOs.User.Base;
using ProcApi.Repositories.Abstracts;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates
{
    public class ApprovalFlowService : IApprovalFlowService
    {
        private readonly IApprovalFlowTemplateRepository _flowTemplateRepository;
        private readonly IUserRepository _userRepository;

        public ApprovalFlowService(IApprovalFlowTemplateRepository flowTemplateRepository, 
            IUserRepository userRepository)
        {
            _flowTemplateRepository = flowTemplateRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<DocumentAction>> CreateApprovals(UserInfo userInfo, Document document, DocumentType type)
        {
            var flowTemplates = await _flowTemplateRepository.GetInitialWithUserByDocumentType(type);
            var currentUser = await _userRepository.GetByIdAsync(userInfo.UserId);

            if (!flowTemplates.Any())
                throw new Exception("no flow template was found");

            var documentActions = new List<DocumentAction>();

            foreach (var flowTemplate in flowTemplates)
            {
                if (!flowTemplate.IsCreator && flowTemplate.UserId is null)
                    throw new Exception("no user was found for template");

                documentActions.Add(new DocumentAction()
                {
                    Document = document,
                    RoleId = flowTemplate.RoleId,
                    UserId = flowTemplate.IsCreator ? userInfo.UserId : flowTemplate.UserId.Value,
                    User = flowTemplate.IsCreator ? currentUser : flowTemplate.User,
                    Order = flowTemplate.Order,
                    IsPerformed = false,
                    ActionPerformed = null,
                });
            }

            return documentActions;
        }
    }
}