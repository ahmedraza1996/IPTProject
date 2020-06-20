using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.adminpanel
{
    public class AddDesVM
    {
        public List<Designation> designations { get; set; }

        public List<Department> departments { get; set; }
    }
}