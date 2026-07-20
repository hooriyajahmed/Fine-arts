using System.ComponentModel.DataAnnotations;

namespace FineArts.Models
{
    public class Evaluation
    {
        [Key]
        public int EvaluationId { get; set; }

        public int PaintingId { get; set; }

        public int StaffId { get; set; }

        public string Remark { get; set; }

        public DateTime EvaluationDate { get; set; }

        public Painting Painting { get; set; }

        public Staff Staff { get; set; }

    }
}
