using Microsoft.Extensions.Localization;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.Exceptions;
using ProcApi.Repositories.Abstracts;
using ProcApi.Resources;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates
{
    public class ApprovalsService : IApprovalsService
    {
        private readonly IApprovalFlowTemplateRepository _flowTemplateRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ApprovalsService(IApprovalFlowTemplateRepository flowTemplateRepository,
            IUserRepository userRepository,
            IStringLocalizer<SharedResource> localizer)
        {
            _flowTemplateRepository = flowTemplateRepository;
            _userRepository = userRepository;
            _localizer = localizer;
        }

        public async Task<IEnumerable<DocumentAction>> InitApprovals(int userId, DocumentType type)
        {
            var flowTemplates = await _flowTemplateRepository.GetInitialWithUserByDocumentType(type);

            if (!flowTemplates.Any())
                throw new Exception("no flow template was found");

            var documentActions = new List<DocumentAction>();

            foreach (var flowTemplate in flowTemplates)
            {
                if (!flowTemplate.IsCreator && !flowTemplate.UserId.HasValue)
                    throw new Exception($"no user was found for template: {flowTemplate.Id}");

                if (flowTemplate.IsCreator)
                    documentActions.Add(await CreateActionForCreator(userId, flowTemplate));
                else
                    documentActions.Add(CreateAction(flowTemplate));
            }

            return documentActions;
        }

        private async Task<DocumentAction> CreateActionForCreator(int userId, ApprovalFlowTemplate template)
        {
            var user = await _userRepository.GetWithRoles(userId);

            if (user is null)
                throw new ValidationException(_localizer["UserNotFound"]);

            var roles = user.Roles.Select(r => r.Id);

            if (!roles.Contains(template.RoleId))
                throw new ValidationException(_localizer["UserHasNoRoleForOperation"]);

            return new DocumentAction()
            {
                RoleId = template.RoleId,
                UserId = user.Id,
                User = user,
                Order = template.Order,
                IsPerformed = false,
                ActionPerformed = null,
            };
        }

        private DocumentAction CreateAction(ApprovalFlowTemplate template)
        {
            return new DocumentAction()
            {
                RoleId = template.RoleId,
                UserId = template.UserId.Value,
                User = template.User,
                Order = template.Order,
                IsPerformed = false,
                ActionPerformed = null,
            };
        }
    }
}