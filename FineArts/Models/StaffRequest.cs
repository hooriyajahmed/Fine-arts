using FineArts.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace FineArts.Models
{
    public class StaffRequest
    {

        [Key]
        public int RequestId { get; set; }

        public string? UserId { get; set; }

        public user? User { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public DateTime JoiningDate { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string ClassHandling { get; set; }

        public string Remarks { get; set; }

        public string Status { get; set; } = "Pending";

        public DateTime RequestDate { get; set; } = DateTime.Now; 
    }
}
