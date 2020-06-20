using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Attendance
{
    public class CourseFaculty
    {
        public int CFID { get; set; }
        public int NumberOfSection { get; set; }
        public int CourseOfferedID { get; set; }
        public int EmpID { get; set; }
    }
}