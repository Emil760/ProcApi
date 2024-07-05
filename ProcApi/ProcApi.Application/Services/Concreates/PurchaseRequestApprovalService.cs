using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.Handlers;
using ProcApi.Application.Handlers.PurchaseRequest;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Concreates;

public class PurchaseRequestApprovalService : IPurchaseRequestApprovalService
{
    private readonly Dictionary<ActionType, IActionHandler> _actionHandlers;

    public PurchaseRequestApprovalService(
        PurchaseRequestApproveHandler approveHandler,
        PurchaseRequestRejectHandler rejectHandler,
        PurchaseRequestReturnHandler returnHandler,
        PurchaseRequestSubmitHandler submitHandler)
    {
        _actionHandlers = new Dictionary<ActionType, IActionHandler>
        {
            [ActionType.Submit] = submitHandler,
            [ActionType.Approve] = approveHandler,
            [ActionType.Reject] = rejectHandler,
            [ActionType.Return] = returnHandler
        };
    }

    public async Task PerformAction(ActionPerformRequest dto, UserInfoModel userInfo)
    {
        var action = _actionHandlers[dto.ActionType];

        await action.PerformAction(dto, userInfo.UserId);
    }
}