using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineExam.Models
{
    public partial class Exam
    {
        public int? Subjectid { get; set; }
        public int? Level { get; set; }
        public int? Minmarks { get; set; }
        public int? Duration { get; set; }

        public virtual Subjects Subject { get; set; }
    }
}
