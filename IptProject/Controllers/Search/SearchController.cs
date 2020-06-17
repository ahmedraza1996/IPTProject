using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers.Search
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult Search()
        {

            Console.WriteLine("testing ");
            ViewData["msg"] = " This is a test msessage";
            //base url 
            ViewData["baseUrlDefaultSearch"] = "https://localhost:44380/api/search/GetSearchResult";
            ViewData["baseUrlFYPSearch"] = "will set";

            return View();
        }
    }
}