namespace FineArts.Models
{
    public class ExhibitionPainting
    {

        public int ExhibitionPaintingId { get; set; }

        public int ExhibitionId { get; set; }

        public int PaintingId { get; set; }

        public decimal QuotedPrice { get; set; }

        public decimal SoldPrice { get; set; }

        public Exhibition Exhibition { get; set; }

        public Painting Painting { get; set; }

      


    }
}
