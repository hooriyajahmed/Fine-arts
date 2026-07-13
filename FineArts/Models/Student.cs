
﻿using FineArts.Areas.Identity.Data;

namespace FineArts.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string? UserId { get; set; }

        public user? User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public DateTime AdmissionDate { get; set; }

        public string Course { get; set; }



    }
    
}
