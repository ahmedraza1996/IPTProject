using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalWebsite.Models
{
    public class StudentVM
    {
        public List<Experience> experiences { get; set; }
        public List<Skill> skills{ get; set; }
        public List<Project> projects { get; set; }
        public List<Framework> frameworkNames { get; set; }

        public List<Organization> organizationNames { get; set; }

        public List<Domain> domains { get; set; }
    }
}