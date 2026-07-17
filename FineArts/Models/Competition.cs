using System.ComponentModel.DataAnnotations;

namespace FineArts.Models
{
    public class Competition
    {
        [Key]
        public int CompetitionId { get; set; }

        public string CompetitionTitle { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Conditions { get; set; }

        public string AwardDetails { get; set; }

        public string imageurl { get; set; }

        public int Staff_Id { get; set; }
        public Staff Staff { get; set; }


    }
}
