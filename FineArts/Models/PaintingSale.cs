namespace FineArts.Models
{
    public class PaintingSale
    {
        public int PaintingSaleId { get; set; }

        public int ExhibitionPaintingId { get; set; }

        public int CustomerId { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal Amount { get; set; }

        public ExhibitionPainting ExhibitionPainting { get; set; }

        public Customer Customer { get; set; }
    }
}
