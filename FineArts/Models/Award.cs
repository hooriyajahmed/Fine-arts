namespace FineArts.Models
{
    public class Award
    {
        public int AwardId { get; set; }

        public int CompetitionId { get; set; }

        public int StudentId { get; set; }

        public string AwardTitle { get; set; }

        public decimal PrizeAmount { get; set; }

        public string Remarks { get; set; }

        public DateTime AwardDate { get; set; }

        public Competition Competition { get; set; }

        public Student Student { get; set; }

    }
}
