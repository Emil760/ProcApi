using Microsoft.Extensions.Localization;
using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.Data.ProcDatabase.Models;
using ProcApi.DTOs.Documents.Requests;
using ProcApi.Exceptions;
using ProcApi.Repositories.Abstracts;
using ProcApi.Repositories.UnitOfWork;
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
        private readonly IUnitOfWork _unitOfWork;

        public ApprovalsService(IApprovalFlowTemplateRepository flowTemplateRepository,
            IUserRepository userRepository,
            IDocumentRepository documentRepository,
            IReleaseStrategyRepository releaseStrategyRepository,
            IStringLocalizer<SharedResource> localizer,
            IUnitOfWork unitOfWork)
        {
            _flowTemplateRepository = flowTemplateRepository;
            _userRepository = userRepository;
            _documentRepository = documentRepository;
            _releaseStrategyRepository = releaseStrategyRepository;
            _localizer = localizer;
            _unitOfWork = unitOfWork;
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
            var document = await _documentRepository.GetWithActionsAsync(dto.DocId);

            if (document is null)
                throw new NotFoundException(_localizer["DocumentNotFound"]);

            var releaseStrategy =
                await _releaseStrategyRepository.GetWithFlowTemplateAsync(document.StatusId, dto.ActionType);

            if (releaseStrategy is null)
                throw new Exception(
                    $"Release strategy not found for Status:{document.Id} ActionType:{dto.ActionType}");

            var userRoles = await _userRepository.GetRoles(userId);

            if (!userRoles.Any())
                throw new NotFoundException(_localizer["UserNotFound"]);

            if (!userRoles.Contains(releaseStrategy.ApprovalFlowTemplate.RoleId))
                throw new ValidationException(_localizer["UserCantPerformAction"]);

            var currentAssignedUser = document.Actions
                .SingleOrDefault(da => da.UserId == userId
                                       && da.RoleId == releaseStrategy.ApprovalFlowTemplate.RoleId
                                       && da.IsAssigned
                                       && !da.IsPerformed);

            if (currentAssignedUser is null)
                throw new ValidationException(_localizer["ActionAlreadyPerformed"]);

            var alreadyPerformedCount = document.Actions.Count(da => da.IsPerformed);

            var performedCount = document.Actions.Count(da => da.Order < currentAssignedUser.Order);

            if (alreadyPerformedCount != performedCount)
                throw new ValidationException(_localizer["ActionAlreadyPerformed"]);
        }

        public async Task ApproveDocumentAsync(ActionPerformRequestDto dto, int userId)
        {
            var document = await _documentRepository.GetWithActionsAsync(dto.DocId);

            var releaseStrategy =
                await _releaseStrategyRepository.GetWithFlowTemplateAsync(document.StatusId, dto.ActionType);

            var currentDocAction = document.Actions
                .Single(da => da.UserId == userId
                              && da.RoleId == releaseStrategy.ApprovalFlowTemplate.RoleId
                              && da.IsAssigned
                              && !da.IsPerformed);

            currentDocAction.ActionPerformed = DateTime.Now;
            currentDocAction.IsPerformed = true;

            document.StatusId = releaseStrategy.AssignStatusId;

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ReturnDocumentAsync(ActionPerformRequestDto dto)
        {
            var document = await _documentRepository.GetWithActionsAsync(dto.DocId);

            var releaseStrategy =
                await _releaseStrategyRepository.GetWithFlowTemplateAsync(document.StatusId, dto.ActionType);

            foreach (var docAction in document.Actions)
            {
                docAction.IsPerformed = false;
                docAction.ActionPerformed = null;
            }

            document.StatusId = releaseStrategy.AssignStatusId;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}