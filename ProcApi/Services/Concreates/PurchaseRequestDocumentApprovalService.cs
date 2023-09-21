using ProcApi.Data.ProcDatabase.Enums;
using ProcApi.DTOs.Documents.Requests;
using ProcApi.DTOs.User.Base;
using ProcApi.Handlers;
using ProcApi.Handlers.PurchaseRequestDocument;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates;

public class PurchaseRequestDocumentApprovalService : IPurchaseRequestDocumentApprovalService
{
    private readonly Dictionary<ActionType, IActionHandler> _actionHandlers;

    public PurchaseRequestDocumentApprovalService(
        PurchaseRequestApproveHandler approveHandler,
        PurchaseRequestRejectHandler rejectHandler,
        PurchaseRequestReturnHandler returnHandler,
        PurchaseRequestSubmitHandler submitHandler)
    {
        _actionHandlers = new Dictionary<ActionType, IActionHandler>();
        _actionHandlers[ActionType.Submit] = submitHandler;
        _actionHandlers[ActionType.Approve] = approveHandler;
        _actionHandlers[ActionType.Reject] = rejectHandler;
        _actionHandlers[ActionType.Return] = returnHandler;
    }

    public async Task PerformAction(ActionPerformRequestDto dto, UserInfo userInfo)
    {
        var action = _actionHandlers[dto.ActionType];

        await action.PerformAction(dto, userInfo.UserId);
    }
}