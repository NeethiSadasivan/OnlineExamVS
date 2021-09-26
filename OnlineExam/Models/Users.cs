using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineExam.Models
{
    public partial class Users
    {
        public int Userid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Mobile { get; set; }
        public DateTime Dob { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Qualification { get; set; }
        public int Yearofcompletion { get; set; }
    }
}
