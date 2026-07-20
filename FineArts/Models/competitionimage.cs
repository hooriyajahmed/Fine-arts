using System.ComponentModel.DataAnnotations;

namespace FineArts.Models
{
    public class competitionimage
    {
        [Key]
        public int CompetitionId { get; set; }

        public string CompetitionTitle { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Conditions { get; set; }

        public string AwardDetails { get; set; }

        public IFormFile path { get; set; }

        public int Staff_Id { get; set; }
        public Staff Staff { get; set; }
    }
}
