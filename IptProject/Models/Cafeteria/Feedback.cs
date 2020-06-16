using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Cafeteria
{
    public class Feedback
    {
        public int FbID { get; set; }
        public DateTime Date { get; set; }
        public string strDate { get; set; }
        public string FDescription { get; set; }
        public int Rating { get; set; }
        public int StudentID { get; set; }

    }
}