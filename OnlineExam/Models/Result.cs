using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineExam.Models
{
    public partial class Result
    {
        public int? Userid { get; set; }
        public int? Level { get; set; }
        public int? Subjectid { get; set; }
        public int? Marks { get; set; }

        public virtual Subjects Subject { get; set; }
        public virtual Users User { get; set; }
    }
}
