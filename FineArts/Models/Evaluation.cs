namespace FineArts.Models
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }

        public int PaintingId { get; set; }

        public int StaffId { get; set; }

        public string MarksCategory { get; set; }

        public string PositiveRemarks { get; set; }

        public string NegativeRemarks { get; set; }

        public string ImprovementRemarks { get; set; }

        public DateTime EvaluationDate { get; set; }

        public Painting Painting { get; set; }

        public Staff Staff { get; set; }
    }
}
