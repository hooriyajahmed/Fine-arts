namespace FineArts.Models
{
    public class Painting
    {
        public int PaintingId { get; set; }

        public int StudentId { get; set; }

        public int CompetitionId { get; set; }

        public string PaintingTitle { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string Poem { get; set; }

        public string Quotation { get; set; }

        public string Story { get; set; }

        public DateTime SubmissionDate { get; set; }

        public string Status { get; set; }

        public Student Student { get; set; }

        public Competition Competition { get; set; }

        //public ICollection<Evaluation> Evaluations { get; set; }

        //public ICollection<ExhibitionPainting> ExhibitionPaintings { get; set; }
    }
}
