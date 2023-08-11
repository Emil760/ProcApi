using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.DTOs.Documents;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class PurchaseRequestDocumentApprovalService : IPurchaseRequestDocumentApprovalService
{
    private readonly IPurchaseRequestDocumentService _purchaseRequestDocumentService;

    private readonly Dictionary<ActionType, Func<Task>> _actionDictionary = new()
    {
        { ActionType.Approve, Approve },
        { ActionType.SaveAsDraft, SaveAsDraft }
    };

    public PurchaseRequestDocumentApprovalService(IPurchaseRequestDocumentService purchaseRequestDocumentService)
    {
        _purchaseRequestDocumentService = purchaseRequestDocumentService;
    }

    public async Task PerformAction(ActionPerformDto dto)
    {
        var action = _actionDictionary[dto.ActionType];
        
        await action.Invoke();
    }

    private static async Task Approve()
    {
        
    }

    private static async Task SaveAsDraft()
    {
        
    }

    public async Task Return()
    {
    }

    public async Task Reject()
    {
    }

    public async Task Reconcile()
    {
    }

    public async Task ValidateForApprove()
    {
    }

    public async Task ValidateForDraft()
    {
    }
}