using Microsoft.Extensions.Localization;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Documents.Requests;
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
        private readonly IDocumentRepository _documentRepository;
        private readonly IReleaseStrategyRepository _releaseStrategyRepository;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ApprovalsService(IApprovalFlowTemplateRepository flowTemplateRepository,
            IUserRepository userRepository,
            IDocumentRepository documentRepository,
            IReleaseStrategyRepository releaseStrategyRepository,
            IStringLocalizer<SharedResource> localizer)
        {
            _flowTemplateRepository = flowTemplateRepository;
            _userRepository = userRepository;
            _documentRepository = documentRepository;
            _releaseStrategyRepository = releaseStrategyRepository;
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

            var userRoles = user!.Roles.Select(r => r.Id);

            if (!userRoles.Any())
                throw new ValidationException(_localizer["UserNotFound"]);

            if (!userRoles.Contains(template.RoleId))
                throw new ValidationException(_localizer["UserHasNoRoleForOperation"]);

            return new DocumentAction()
            {
                RoleId = template.RoleId,
                UserId = user.Id,
                User = user,
                Order = template.Order,
                IsPerformed = false,
                ActionPerformed = null,
                IsAssigned = true,
                ActionAssigned = DateTime.Now
            };
        }

        private DocumentAction CreateAction(ApprovalFlowTemplate template)
        {
            return new DocumentAction()
            {
                RoleId = template.RoleId,
                UserId = template.UserId!.Value,
                User = template.User!,
                Order = template.Order,
                IsPerformed = false,
                ActionPerformed = null,
                IsAssigned = true,
                ActionAssigned = DateTime.Now
            };
        }

        public async Task CanPerformAction(ActionPerformRequestDto dto, int userId)
        {
            var documentStatus = await _documentRepository.GetStatus(dto.DocId);
            if (documentStatus == 0)
                throw new NotFoundException(_localizer["DocumentNotFound"]);

            var userRoles = await _userRepository.GetRoles(userId);
            if (!userRoles.Any())
                throw new NotFoundException(_localizer["UserNotFound"]);

            var releaseStrategy =
                await _releaseStrategyRepository.GetWithFlowTemplate(documentStatus, dto.ActionType);
            if (releaseStrategy is null)
                throw new Exception(
                    $"Release strategy not found for Status:{documentStatus} ActionType:{dto.ActionType}");

            if (!userRoles.Contains(releaseStrategy.ApprovalFlowTemplate.RoleId))
                throw new ValidationException(_localizer["UserCantPerformAction"]);
        }

        public async Task CanPerformActionAndApprove(ActionPerformRequestDto dto, int userId)
        {
            var document = await _documentRepository.GetWithActions(dto.DocId);
            if (document is null)
                throw new NotFoundException(_localizer["DocumentNotFound"]);

            var userRoles = await _userRepository.GetRoles(userId);
            if (!userRoles.Any())
                throw new NotFoundException(_localizer["UserNotFound"]);

            var roleToApprove = await _releaseStrategyRepository.GetRoleFromApprovalFlowTemplate(
                document.StatusId,
                dto.ActionType);
            if (roleToApprove == 0)
                throw new Exception(
                    $"Release strategy not found for Status:{document.StatusId} ActionType:{dto.ActionType}");

            if (!userRoles.Contains(roleToApprove))
                throw new ValidationException(_localizer["UserCantPerformAction"]);

            CanApproveDocument(document.Actions, userId, roleToApprove);
        }

        private void CanApproveDocument(IEnumerable<DocumentAction> documentActions, int userId, int roleId)
        {
            if (documentActions.Any(da => da.UserId == userId && da.RoleId == roleId && da.IsPerformed))
                throw new ValidationException(_localizer["ActionAlreadyPerformed"]);

            var alreadyPerformedCount = documentActions.Count(da => da.IsPerformed);

            var currentAssignedUser =
                documentActions.Single(da => da.UserId == userId && da.RoleId == roleId && da.IsAssigned);

            var performedCount = documentActions.Count(da => da.Order < currentAssignedUser.Order);

            if (alreadyPerformedCount != performedCount)
                throw new ValidationException(_localizer["ActionAlreadyPerformed"]);
        }
    }
}