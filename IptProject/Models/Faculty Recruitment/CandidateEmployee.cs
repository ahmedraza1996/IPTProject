using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IptApis.Models.FacultyRecruitment
{
    public class CandidateEmployee
    {
        public int ECandidateID { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string EName { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(16, ErrorMessage = "Must be between 8 and 16 characters", MinimumLength = 8)]
        //[DataType(DataType.Password)]
        public string Epassword { get; set; }

        [Required(ErrorMessage = "Password is required")]
        //[DataType(DataType.Password)]
        [Compare("Epassword")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string EAddress { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        [StringLength(11, ErrorMessage = "Phone Number Must be of 11 number", MinimumLength = 11)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "This Field is required")]
        public string EducationalLevel { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public int ExperienceYears { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public string CVPath { get; set; }
        [Required(ErrorMessage = "This Field is required")]
        public string CoverLetterPath { get; set; }

    }
}