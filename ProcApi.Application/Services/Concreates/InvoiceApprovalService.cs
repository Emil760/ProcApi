using ProcApi.Application.DTOs.Documents.Requests;
using ProcApi.Application.Handlers;
using ProcApi.Application.Handlers.Invoice;
using ProcApi.Application.Services.Abstracts;
using ProcApi.Domain.Enums;
using ProcApi.Domain.Models;

namespace ProcApi.Application.Services.Concreates;

public class InvoiceApprovalService : IInvoiceApprovalService
{
    private readonly Dictionary<ActionType, IActionHandler> _actionHandlers;

    public InvoiceApprovalService(
        InvoiceApproveHandler approveHandler,
        InvoiceReturnHandler returnHandler,
        InvoiceRejectHandler rejectHandler,
        InvoiceSubmitHandler submitHandler
    )
    {
        _actionHandlers = new Dictionary<ActionType, IActionHandler>();
        _actionHandlers[ActionType.Submit] = submitHandler;
        _actionHandlers[ActionType.Approve] = approveHandler;
        _actionHandlers[ActionType.Reject] = rejectHandler;
        _actionHandlers[ActionType.Return] = returnHandler;
    }

    public async Task PerformAction(ActionPerformRequestDto dto, UserInfoModel userInfo)
    {
        var action = _actionHandlers[dto.ActionType];

        await action.PerformAction(dto, userInfo.UserId);
    }
}