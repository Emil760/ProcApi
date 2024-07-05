using ProcApi.Application.DTOs.Documents.Requests;

namespace ProcApi.Application.Handlers;

public interface IActionHandler
{
    Task PerformAction(ActionPerformRequest dto, int userId);
}