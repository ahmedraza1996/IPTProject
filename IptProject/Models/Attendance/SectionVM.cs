using IptProject.Models.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Attendance
{
    public class SectionVM
    {
        public List<Section> sections { get; set; }
        public string EmpName { get; set; }
        public int CourseID { get; set; }
    }
}