namespace ProcApi.Application.DTOs.ReservedItem.Responses
{
    public class ReserveItemResponse
    {
        public int Id { get; set; }
        public int GoodReceiptNoteItemId { get; set; }
        public string GoodReceiptNoteNumber { get; set; }
        public string MaterialName { get; set; }
        public string UnitOfMeasureName { get; set; }
        public decimal Quantity { get; set; }
        public bool IsActive { get; set; }
    }
}
