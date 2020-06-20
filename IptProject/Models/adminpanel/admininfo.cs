using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IptProject.Models.adminpanel
{
    public class admininfo
    {
        public admininfo()
        {

        }
        public admininfo(string adminName, string adminEmail, string adminPassword, string adminPhone)
        {
            this.adminName = adminName;
            this.adminEmail = adminEmail;
            this.adminPassword = adminPassword;
            this.adminPhone = adminPhone;
        }

        //public int adminId { get; set; }

        //[Required(ErrorMessage ="Please Enter the Name")]
        //[Display(Name = "Admin Name")]
        public string adminName { get; set; }

        //[Required(ErrorMessage = "Please Enter the Email")]
        //[Display(Name = "Admin Email")]
        public string adminEmail { get; set; }

        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Please Enter the Password")]
        //[Display(Name = "Admin Password")]
        public string adminPassword { get; set; }

        //[Required(ErrorMessage = "Please Enter the Phone")]
        //[Display(Name = "Admin Phone")]
        public string adminPhone { get; set; }
    }
}