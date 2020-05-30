using IptProject.Models.CourseFeedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers.Course_Feedback
{
    public class CourseFeedbackController : Controller
    {
        // GET: CourseFeedback
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowFeedbackForm()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44380/api/");
                //HTTP GET
                var responseTask = client.GetAsync("coursefeedback/getQuestions?courseName=AAA&courseType=1");
                responseTask.Wait();

                var result = responseTask.Result;
               

                    var readTask = result.Content.ReadAsAsync<List<Questions>>();
                    readTask.Wait();

                    var fooditems = readTask.Result;

                    return View(fooditems);
                
            }
        }
        
    }
}