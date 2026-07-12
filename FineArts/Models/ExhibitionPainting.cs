namespace FineArts.Models
{
    public class ExhibitionPainting
    {
        public int ExhibitionPaintingId { get; set; }

        public int ExhibitionId { get; set; }

        public int PaintingId { get; set; }

        public decimal QuotedPrice { get; set; }

        public decimal SoldPrice { get; set; }

        public bool SoldStatus { get; set; }

        public bool PaymentGiven { get; set; }

        public Exhibition Exhibition { get; set; }

        public Painting Painting { get; set; }

        //public ICollection<PaintingSale> PaintingSales { get; set; }

    }
}
