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
    public class admin_facultyController : Controller
    {
        // GET: admin_faculty
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult FacultyLogin()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FacultyPage(FormCollection formCollection)
        {
            facultiesVM facultiesVM = new facultiesVM();

            faculties faculties = new faculties();
            faculties facultiesL = new faculties();

            string Email = formCollection[1];
            string EPassword = formCollection[2];

            faculties.Email = Email;
            faculties.EPassword = EPassword;

            var json = JsonConvert.SerializeObject(new facultiesVM { Email = Email, SPassword = EPassword });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage result = await client.PostAsync("admin_faculty/FacultyLogin/", data);
                var response = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(response);
                //facultiesL = JsonConvert.DeserializeObject<faculties>(response);
                if (response == "null")
                {
                    //means login credentials were wrong
                    return View("FacultyLogin");
                }
                else
                {
                    //facultiesVM.faculties = facultiesL;
                    return View("Index");
                    //succeed logging in
                }
            }

        }













    }
}