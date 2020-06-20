using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Attendance
{
    public class CoursesVM
    {
        public List<AllStudentCourses> allStudentCourses { get; set; }

        public List<StudentCoursesAttendance> studentcourseattendances { get; set; }
    }
}