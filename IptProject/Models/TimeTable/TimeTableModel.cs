using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.TimeTable
{
    public class TimeTableModel
    {
        public TimeTableModel(String coursename, string Section, string CourseInstructor, String Room, int timeslot, String Batch, int credithour, int day)
        {
            this.coursename = coursename;
            this.Section = Section;
            this.CourseInstructor = CourseInstructor;
            this.Room = Room;
            this.timeslot = timeslot;
            this.Batch = Batch;
            this.credithour = credithour;
            this.day = day;

        }

        public String coursename { get; set; }
        public String Section { get; set; }
        public String CourseInstructor { get; set; }
        public String Room { get; set; }
        public int timeslot { get; set; }
        public String Batch { get; set; }
        public int credithour { get; set; }
        public int day { get; set; }

    }
}