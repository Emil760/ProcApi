using ProcApi.Domain.Interfaces;

namespace ProcApi.Domain.Entities
{
    public class ReservedItem : IEntity<int>
    {
        public int Id { get; set; }
        public GoodReceiptNoteItem GoodReceiptNoteItem { get; set; }
        public string GoodReceiptNoteNumber { get; set; }
        public int GoodReceiptNoteItemId { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public int UnitOfMeasureId { get; set; }
        public decimal Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
