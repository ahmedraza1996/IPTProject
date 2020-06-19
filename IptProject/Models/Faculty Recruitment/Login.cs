using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace IptProject.Models.Faculty_Recruitment
{
    public class Login
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username {get; set;}

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string LoginAs { get; set; }
    }
}