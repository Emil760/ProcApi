namespace ProcApi.Data.ProcDatabase.Models
{
    public class PurchageRequestDocumentItem
    {
        public int Id { get; set; }
        public int PurchageRequestDocumentId { get; set; }
        public PurchageRequestDocument PurchageRequestDocument { get; set; }
        public int UnitOfMeasureId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
