using ProcApi.Application.DTOs.Documents.Requests;

namespace ProcApi.Application.Handlers;

public interface IActionHandler
{
    Task PerformAction(ActionPerformRequestDto dto, int userId);
}