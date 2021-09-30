using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineExam.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            Exam = new HashSet<Exam>();
            Questions = new HashSet<Questions>();
            Result = new HashSet<Result>();
        }

        public int Subjectid { get; set; }
        public string Subjectname { get; set; }

        public virtual ICollection<Exam> Exam { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<Result> Result { get; set; }
    }
}
