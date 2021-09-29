using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineExam.Models
{
    public partial class Questions
    {
        public int Questionid { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int? Level { get; set; }
        public int? Correctanswer { get; set; }
        public int? Subjectid { get; set; }

        public virtual Subjects Subject { get; set; }
    }
}
