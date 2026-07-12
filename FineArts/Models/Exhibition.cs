namespace FineArts.Models
{
    public class Exhibition
    {
        public int ExhibitionId { get; set; }

        public string ExhibitionName { get; set; }

        public string Venue { get; set; }

        public string City { get; set; }

        public DateTime ExhibitionDate { get; set; }

        public string Description { get; set; }

        //public ICollection<ExhibitionPainting> ExhibitionPaintings { get; set; }
    
}
}
