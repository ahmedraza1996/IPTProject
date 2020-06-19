using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.TimeTable
{
    public class TimeTableData
    {
        public String empname { set; get; }
        public String course { set; get; }
        public String section { set; get; }
        public String batch { set; get; }
        public String room { set; get; }
        public int timeslot { set; get; }
        public int day { set; get; }
    }
}