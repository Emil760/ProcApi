namespace ProcApi.Application.DTOs.Delegation.Responses;

public class DelegationResponse
{
    public int Id { get; set; }
    public string FromUserName { get; set; }
    public string ToUserName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}