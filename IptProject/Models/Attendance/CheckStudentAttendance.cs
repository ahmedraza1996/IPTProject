using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Attendance
{
    public class CheckStudentAttendance
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string CourseStatus { get; set; }
        public int StudentID { get; set; }
        public string SName { get; set; }
        public string Email { get; set; }
        public int AttendanceID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string AttendanceStatus { get; set; }
        public int ClassDuration { get; set; }
        public int EnrollmentID { get; set; }
    }
}