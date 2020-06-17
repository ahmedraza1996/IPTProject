using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers.Bot
{
    public class BotController : Controller
    {
        // GET: Bot
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Page";

            return View();
        }
        public ActionResult ChatApplication()
        {
            ViewBag.Message = "Chat Application Interface";

            return View();
        }
        public ActionResult Chatbot()
        {
            ViewBag.Message = "Chat Bot Interface";

            return View();
        }
  
    }
}