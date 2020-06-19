using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Attendance
{
    public class TeacherData
    {
        public Employee employee { get; set; }
        public List<Employee> employees { get; set; }
        public List<Course> courses { get; set; }     

        public List<Semester> semesters { get; set; }
    }
}