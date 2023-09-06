using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.DTOs.Documents.Requests;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class PurchaseRequestDocumentApprovalService : IPurchaseRequestDocumentApprovalService
{
    private readonly Dictionary<ActionType, Func<Task>> _actionDictionary = new()
    {
        { ActionType.Approve, Approve },
        { ActionType.SaveAsDraft, SaveAsDraft }
    };

    public PurchaseRequestDocumentApprovalService()
    {
        
    }

    public async Task PerformAction(ActionPerformRequestDto requestDto)
    {
        var action = _actionDictionary[requestDto.ActionType];

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