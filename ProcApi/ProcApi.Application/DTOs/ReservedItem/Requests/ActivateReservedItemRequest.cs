namespace ProcApi.Application.DTOs.ReservedItem.Requests
{
    public class ActivateReservedItemRequest
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
