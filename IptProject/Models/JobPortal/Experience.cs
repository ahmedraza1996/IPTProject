using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalWebsite.Models
{
    public class Experience
    {
        public int ExpID { get; set; }
        public int StudentID { get; set; }
        public string Designation { get; set; }
        public string JDescription { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string OrganizationName { get; set; }

    }
}