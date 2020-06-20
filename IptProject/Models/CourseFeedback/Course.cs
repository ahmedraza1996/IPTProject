using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.CourseFeedback
{
    public class Course
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string CourseID { get; set; }
        public string FeedbackID { get; set; }
        public string isSubmitted { get; set; }
        public int type { get; set; }
    }
}