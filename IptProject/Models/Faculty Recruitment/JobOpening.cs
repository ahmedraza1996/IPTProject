using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IptApis.Models.FacultyRecruitment
{
    public class JobOpening
    {
        public int JobID { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public int MinExperience { get; set; }

        [Required(ErrorMessage = "Job Description required")]
        public string JobDescription { get; set; }

        public string DatePosted { get; set; }

        public string ExpectedStartDate { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public string Department { get; set; }

        public int DesignationID { get; set; }
        public int DepartmentID { get; set; }

    }
}