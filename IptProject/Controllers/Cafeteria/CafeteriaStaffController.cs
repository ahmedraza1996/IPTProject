using IptProject.Models.Cafeteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers.Cafeteria
{
    public class CafeteriaStaffController : Controller
    {
        // GET: CafeteriaStaff
        public ActionResult GetFeedbacks()
        {
            List<Feedback> lstfb = new List<Feedback>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("cafeteriastaff/GetFeedback");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Feedback[]>();
                    readTask.Wait();

                    var feedbacks = readTask.Result;

                    foreach (var item in feedbacks)
                    {
                        item.strDate = item.Date.ToString("dd-MM-yyyy");
                        lstfb.Add(item);
                    }
                }
            }

            return View(lstfb);
        }

    }
}