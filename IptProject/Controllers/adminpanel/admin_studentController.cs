using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using IptProject.Models.adminpanel;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace IptProject.Controllers.adminpanel
{
    public class admin_studentController : Controller
    {
        // GET: admin_student
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult StudentLogin()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> StudentPage(FormCollection formCollection)
        {
            studentsVM studentsVM = new studentsVM();

            students students = new students();
            students studentsL = new students();

            string Email = formCollection[1];
            string SPassword = formCollection[2];

            students.Email = Email;
            students.SPassword = SPassword;

            var json = JsonConvert.SerializeObject(new facultiesVM { Email = Email, SPassword = SPassword });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage result = await client.PostAsync("admin_student/StudentLogin/", data);
                var response = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(response);
                //studentsL = JsonConvert.DeserializeObject<students>(response);
                if (response == "null")
                {
                    //means login credentials were wrong
                    return View("StudentLogin");
                }
                else
                {
                    //studentsVM.students = studentsL;
                    return View("Index");
                    //succeed logging in
                }
            }

        }








    }
}