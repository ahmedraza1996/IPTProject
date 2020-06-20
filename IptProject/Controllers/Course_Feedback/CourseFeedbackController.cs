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
        //this will hold both the name and feedback id 0 index for feedbackId 1 index for name 
        List<string> feedbackIds = new List<string>();
        
        // GET: CourseFeedback
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowFeedbackForm(string id, string type)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //for(var i = 0; i < feedbackIds.Count; i++)
                //{
                //    if (feedbackIds[i] == name)
                //    {
                        Debug.WriteLine("AAAA");
                if (type == null)
                {
                    return RedirectToAction("ShowCourseList", "CourseFeedback");
                }
                        var responseTask = client.GetAsync("coursefeedback/getQuestions?courseName=" + id+ "&courseType=" + type[1]);
                        responseTask.Wait();

                        var result = responseTask.Result;


                        var readTask = result.Content.ReadAsAsync<List<Questions>>();
                        readTask.Wait();

                    var userCookie = new HttpCookie("feedbackId", id);
                    HttpContext.Response.Cookies.Add(userCookie);
                var questions = readTask.Result;
                        //questions[0].FeedbackID = feedbackIds[i - 1];
                        return View(questions);
                //    }
                //}
                //HTTP GET
              
                
            }
            return null;
        }
        public ActionResult ShowCourseList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("coursefeedback/getAllCourses?studentID=16k4060");
                responseTask.Wait();

                var result = responseTask.Result;


                var readTask = result.Content.ReadAsAsync<List<Course>>();
                readTask.Wait();
                var courseList = readTask.Result;
                foreach( var i in courseList)
                {
                    feedbackIds.Add(i.FeedbackID);
                    feedbackIds.Add(i.CourseName);
/*                    var userCookie = new HttpCookie(i.CourseName, courseList[0].FeedbackID);
                    HttpContext.Response.Cookies.Add(userCookie);*/
                    var ctype = i.CourseName.Substring(i.CourseName.Length - 3);
                    if (ctype == "Lab")
                    {
                        Debug.WriteLine("This is lab");
                        i.type = 2;
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