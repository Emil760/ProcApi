using Microsoft.Extensions.Localization;
using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Constants;
using ProcApi.Domain.Entities;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Exceptions;
using ProcApi.Infrastructure.Repositories.Abstracts;
using ProcApi.Infrastructure.Repositories.UnitOfWork;
using ProcApi.Infrastructure.Resources;

namespace ProcApi.Application.Services.Concreates;

public class ApprovalsService : IApprovalsService
{
    private readonly IApprovalFlowTemplateRepository _flowTemplateRepository;
    private readonly IUserRepository _userRepository;
    private readonly IDocumentRepository _documentRepository;
    private readonly IReleaseStrategyTemplateRepository _releaseStrategyTemplateRepository;
    private readonly IDocumentActionRepository _documentActionRepository;
    private readonly IStringLocalizer<SharedResource> _localizer;
    private readonly IUnitOfWork _unitOfWork;

    public ApprovalsService(IApprovalFlowTemplateRepository flowTemplateRepository,
        IUserRepository userRepository,
        IDocumentRepository documentRepository,
        IReleaseStrategyTemplateRepository releaseStrategyTemplateRepository,
        IDocumentActionRepository documentActionRepository,
        IStringLocalizer<SharedResource> localizer,
        IUnitOfWork unitOfWork)
    {
        _flowTemplateRepository = flowTemplateRepository;
        _userRepository = userRepository;
        _documentRepository = documentRepository;
        _releaseStrategyTemplateRepository = releaseStrategyTemplateRepository;
        _documentActionRepository = documentActionRepository;
        _localizer = localizer;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<DocumentAction>> InitApprovals(int documentId, int userId, DocumentType type)
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
        var user = await _userRepository.GetWithRolesById(userId);

        var userRoles = user!.Roles.Select(r => r.Id);

        if (!userRoles.Any())
            throw new ValidationException(_localizer[LocalizationKeys.USER_NOT_FOUND]);

        if (!userRoles.Contains(template.RoleId))
            throw new ValidationException(_localizer[LocalizationKeys.USER_HAS_NOT_ROLE_FOR_OPERATION]);

        return new DocumentAction
        {
            RoleId = template.RoleId,
            AssignerId = user.Id,
            Assigner = user,
            Order = template.Order,
            IsPerformed = false,
            ActionPerformed = null,
            IsAssigned = true,
            ActionAssigned = DateTime.Now
        };
    }

    private DocumentAction CreateAction(ApprovalFlowTemplate template)
    {
        return new DocumentAction
        {
            RoleId = template.RoleId,
            AssignerId = template.UserId!.Value,
            Assigner = template.User!,
            Order = template.Order,
            IsPerformed = false,
            ActionPerformed = null,
            IsAssigned = true,
            ActionAssigned = DateTime.Now
        };
    }

    public async Task CanPerformAction(ActionPerformRequest dto, int userId)
    {
        var document = await _documentRepository.GetWithActionsAsync(dto.DocId);

        if (document is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NOT_FOUND]);

        var releaseStrategy =
            await _releaseStrategyTemplateRepository.GetWithFlowTemplateByStatusAndTypeAndConfigurationAsync(
                document.FlowCodes, document.DocumentStatusId, dto.ActionType);

        if (releaseStrategy is null)
            throw new Exception(
                $"Release strategy not found for Status:{document.Id} ActionType:{dto.ActionType}");

        var performedCount = document.Actions.Count(da => da.IsPerformed);

        var currApprover = document.Actions
            .OrderBy(da => da.Order)
            .Skip(performedCount)
            .Take(1)
            .SingleOrDefault();

        if (currApprover is null)
            throw new ValidationException(_localizer[LocalizationKeys.ACTION_ALREADY_PERFORMED]);

        if (currApprover.RoleId != releaseStrategy.ApprovalFlowTemplate.RoleId)
            throw new Exception(
                $"ApprovalFlowTemplate dismatch for CurrentRole:{currApprover.RoleId} ApprovalFlowTemplateRole:{releaseStrategy.ApprovalFlowTemplate.RoleId}");

        var userRolesSet = (await _userRepository.GetUserRolesWithDelegatedRoles(userId, currApprover.AssignerId))
            .ToHashSet();

        var hasRole = userRolesSet
            .Any(ur => ur.UserId == currApprover.AssignerId && ur.RoleId == currApprover.RoleId);

        if (!hasRole)
            throw new ValidationException(_localizer[LocalizationKeys.USER_CAN_PERFORME_ACTION]);
    }

    public async Task ApproveDocumentAsync(ActionPerformRequest dto, int userId)
    {
        var document = await _documentRepository.GetWithActionsAsync(dto.DocId);

        var releaseStrategy =
            await _releaseStrategyTemplateRepository.GetWithFlowTemplateByStatusAndTypeAndConfigurationAsync(
                document.FlowCodes, document.DocumentStatusId, dto.ActionType);

        var performedCount = document.Actions.Count(da => da.IsPerformed);

        var currApprover = document.Actions
            .OrderBy(da => da.Order)
            .Skip(performedCount)
            .Take(1)
            .SingleOrDefault();

        currApprover.PerformerId = userId;
        currApprover.ActionPerformed = DateTime.Now;
        currApprover.IsPerformed = true;

        if (releaseStrategy.ApprovalFlowTemplate.IsMultiple)
        {
            var allMultipleAssignerPerformed = document.Actions
                .Where(da => da.RoleId == currApprover.RoleId)
                .All(da => da.IsPerformed);

            if (allMultipleAssignerPerformed)
                document.DocumentStatusId = releaseStrategy!.AssignStatusId;
        }
        else
        {
            document.DocumentStatusId = releaseStrategy!.AssignStatusId;
        }

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ReturnDocumentAsync(ActionPerformRequest dto)
    {
        var document = await _documentRepository.GetWithActionsAsync(dto.DocId);

        var releaseStrategy =
            await _releaseStrategyTemplateRepository.GetWithFlowTemplateByStatusAndTypeAndConfigurationAsync(
                document.FlowCodes, document.DocumentStatusId, dto.ActionType);

        foreach (var docAction in document.Actions)
        {
            docAction.IsPerformed = false;
            docAction.ActionPerformed = null;
        }

        document.DocumentStatusId = releaseStrategy!.AssignStatusId;

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RejectDocumentAsync(ActionPerformRequest dto)
    {
        var document = await _documentRepository.GetByIdAsync(dto.DocId);

        var releaseStrategy =
            await _releaseStrategyTemplateRepository.GetWithFlowTemplateByStatusAndTypeAndConfigurationAsync(
                document.FlowCodes, document.DocumentStatusId, dto.ActionType);

        document.DocumentStatusId = releaseStrategy!.AssignStatusId;

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddApprovalToDocument(int documentId, int userId, Roles role, DocumentType documentType)
    {
        var userHasRole = await _userRepository.HasRoleAsync(userId, role);
        if (!userHasRole)
            throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND_OR_NOT_IN_ROLE]);

        var alreadyHasPerformer = await _documentActionRepository.HasByDocumentIdAndRoleAndUserId(
            documentId, userId, role);

        if (alreadyHasPerformer)
        {
            var performer = await _documentActionRepository.GetByDocumentIdAndRole(documentId, role);
            performer.AssignerId = userId;
            performer.ActionAssigned = DateTime.Now;
            await _unitOfWork.SaveChangesAsync();
            return;
        }

        var document = await _documentRepository.GetByIdAsync(documentId);
        if (document is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NOT_FOUND]);

        var flowTemplate = await _flowTemplateRepository.GetByRoleAndDocumentTypeAndMultiple(role, documentType, false);
        if (flowTemplate is null)
            throw new Exception($"flow template not found for role: {role} doc type: {documentType}");

        AddFlowCodeToDocument(document, flowTemplate.FlowCode);

        _documentActionRepository.Insert(new DocumentAction()
        {
            DocumentId = documentId,
            AssignerId = userId,
            IsAssigned = true,
            ActionAssigned = DateTime.Now,
            IsPerformed = false,
            ActionPerformed = null,
            RoleId = (int)role,
            Order = flowTemplate.Order
        });

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveApprovalFromDocument(int documentId, int userId, Roles role, DocumentType documentType)
    {
        var alreadyHasPerformer = await _documentActionRepository.HasByDocumentIdAndRoleAndUserId(
            documentId, userId, role);

        if (!alreadyHasPerformer)
            return;

        var document = await _documentRepository.GetWithActionsAsync(documentId);
        if (document is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NOT_FOUND]);

        var flowTemplate = await _flowTemplateRepository.GetByRoleAndDocumentTypeAndMultiple(role, documentType, false);
        if (flowTemplate is null)
            throw new Exception($"multiple flow template not found for role: {role} doc type: {documentType}");

        RemoveFlowCodeFromDocument(document, flowTemplate.FlowCode);

        var documentAction = document.Actions.SingleOrDefault(da => da.RoleId == (int)role && da.AssignerId == userId);

        if (documentAction is not null)
            _documentActionRepository.DeleteById(documentAction);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddMultipleApprovalToDocument(int documentId, int userId, Roles role, DocumentType documentType)
    {
        var userHasRole = await _userRepository.HasRoleAsync(userId, role);
        if (!userHasRole)
            throw new NotFoundException(_localizer[LocalizationKeys.USER_NOT_FOUND_OR_NOT_IN_ROLE]);

        var alreadyHasPerformer = await _documentActionRepository.HasByDocumentIdAndRoleAndUserId(
            documentId, userId, role);

        if (alreadyHasPerformer)
            return;

        var document = await _documentRepository.GetByIdAsync(documentId);
        if (document is null)
            throw new NotFoundException(_localizer[LocalizationKeys.DOCUMENT_NOT_FOUND]);

        var flowTemplate = await _flowTemplateRepository.GetByRoleAndDocumentTypeAndMultiple(role, documentType, true);
        if (flowTemplate is null)
            throw new Exception($"multiple flow template not found for role: {role} doc type: {documentType}");

        AddFlowCodeToDocument(document, flowTemplate.FlowCode);

        _documentActionRepository.Insert(new DocumentAction
        {
            DocumentId = documentId,
            AssignerId = userId,
            IsAssigned = true,
            ActionAssigned = DateTime.Now,
            IsPerformed = false,
            ActionPerformed = null,
            RoleId = (int)role,
            Order = flowTemplate.Order
        });

        await _unitOfWork.SaveChangesAsync();
    }

    private void AddFlowCodeToDocument(Document document, string flowCode)
    {
        var codes = document.FlowCodes.Split("_");
        if (codes.All(c => c != flowCode))
            document.FlowCodes += "_" + flowCode;
    }

    private void RemoveFlowCodeFromDocument(Document document, string flowCode)
    {
        var codes = document.FlowCodes.Split("_");
        string flowCodes = "";
        for (int i = 0; i < codes.Length; i++)
        {
            if (codes[i] != flowCode)
            {
                flowCodes += codes[i];
                if (i < codes.Length - 1)
                {
                    if (codes[i + 1] != flowCode)
                    {
                        flowCodes += "_";
                    }
                }
            }
        }

        document.FlowCodes = flowCodes;
    }
}