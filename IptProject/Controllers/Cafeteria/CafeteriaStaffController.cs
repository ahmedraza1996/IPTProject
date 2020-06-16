using IptProject.Models.Cafeteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers.Cafeteria
{
    public class CafeteriaStaffController : Controller
    {
        // GET: CafeteriaStaff
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TopUpWallet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TopUpWallet(Wallet obj)
        {
            return View();
        }
    }
}