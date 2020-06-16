using IptProject.Models.CourseFeedback;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ActionResult ShowFeedbackForm(string name, string type)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44380/api/");
                //HTTP GET
                var responseTask = client.GetAsync("coursefeedback/getQuestions?courseName="+name+"&courseType="+type);
                responseTask.Wait();

                var result = responseTask.Result;
               

                    var readTask = result.Content.ReadAsAsync<List<Questions>>();
                    readTask.Wait();

                    var questions = readTask.Result;

                    return View(questions);
                
            }
        }
        public ActionResult ShowCourseList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44380/api/");
                //HTTP GET
                var responseTask = client.GetAsync("coursefeedback/getAllCourses?studentID=16k3950");
                responseTask.Wait();

                var result = responseTask.Result;


                var readTask = result.Content.ReadAsAsync<List<Course>>();
                readTask.Wait();
                var courseList = readTask.Result;
                List<int> ctypes = new List<int>();
                foreach( var i in courseList)
                {
                    var ctype = i.CourseName.Substring(i.CourseName.Length - 3);
                    if (ctype == "Lab")
                    {
                        Debug.WriteLine("This is lab");
                        i.type = 0;
                    }
                    else
                    {
                        i.type = 1;
                    }
                }
                return View(courseList);
            }
        }
        
    }
}