using FineArts.Areas.Identity.Data;

namespace FineArts.Models
{
    public class Staff
    {
        public int StaffId { get; set; }

        public string? UserId { get; set; }

        public user? User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime JoiningDate { get; set; }

        public string Subject { get; set; }

        public string ClassHandling { get; set; }

        public string Remarks { get; set; }

        //public ICollection<Competition> Competitions { get; set; }

        //public ICollection<Evaluation> Evaluations { get; set; }

    }
}
