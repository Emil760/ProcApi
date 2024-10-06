namespace ProcApi.Application.DTOs.ReservedItem.Requests
{
    public class SaveReservedItemRequest
    {
        public int GoodReceiptNoteItemId { get; set; }
        public decimal Quantity { get; set; }
    }
}
