namespace ProcApi.Application.DTOs.Delegation.Requests;

public class CreateDelegationRequest
{
    public int FromUserId { get; set; }
    public int ToUserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}