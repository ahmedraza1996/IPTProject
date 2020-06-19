using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Attendance
{
    public class Attend
    {


        public int AttendanceID { get; set; }
        public string AttendanceDate { get; set; }
        public string AttendanceStatus { get; set; }
        public int ClassDuration { get; set; }
        public int EnrollmentID { get; set; }


    }
}