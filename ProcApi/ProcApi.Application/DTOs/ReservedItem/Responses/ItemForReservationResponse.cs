namespace ProcApi.Application.DTOs.ReservedItem.Responses
{
    public class ItemForReservationResponse
    {
        public int GoodReceiptNoteItemId { get; set; }
        public int GoodReceiptNoteNumber { get; set; }
        public string MaterialName { get; set; }
        public string UnitOfMeasureName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UsedQuantity { get; set; }
    }
}
