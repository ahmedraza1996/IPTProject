using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.JobPortal
{
    public class StudentVM
    {
        public int StudentID { get; set; }
        public List<Experience> experiences { get; set; }
        public List<Skill> skills{ get; set; }
        public List<Project> projects { get; set; }
        public List<Framework> frameworkNames { get; set; }

        public List<Organization> organizationNames { get; set; }

        public List<Domain> domains { get; set; }
    }
}