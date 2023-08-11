namespace ProcApi.Data.ProcDatabase.Models
{
    public class PurchaseRequestDocumentItem
    {
        public int Id { get; set; }
        public int PurchaseRequestDocumentId { get; set; }
        public PurchaseRequestDocument PurchaseRequestDocument { get; set; }
        public int UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
