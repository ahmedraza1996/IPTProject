using JobPortalWebsite.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers.JobPortal
{
    public class StudentProfileController: Controller
    {
        //public ActionResult Index()
        public async Task<ActionResult> Profile()

        {
            string Baseurl = "https://localhost:44380/";
            List<Experience> experiences = new List<Experience>();

            List<Skill> skills = new List<Skill>();

            List<Project> projects = new List<Project>();
            List<Framework> frameworkNames = new List<Framework>();
            List<Organization> organizations = new List<Organization>();
            List<Domain> domains = new List<Domain>();

            StudentVM studentVM = new StudentVM();


            using (var client = new HttpClient())
            {
                String studentID = "163870";
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res1 = await client.GetAsync("api/studentProfile/GetExperienceByID/" + studentID);
                HttpResponseMessage Res2 = await client.GetAsync("api/studentProfile/GetProjectsByID/3870");
                HttpResponseMessage Res3 = await client.GetAsync("api/studentProfile/GetSkillsByID/" + studentID);
                HttpResponseMessage Res4 = await client.GetAsync("api/studentProfile/GetAllFrameworkName");
                HttpResponseMessage Res5 = await client.GetAsync("api/studentProfile/GetOrganizations");
                HttpResponseMessage Res6 = await client.GetAsync("api/studentProfile/GetDomains");


                //Checking the response is successful or not which is sent using HttpClient  
                if (Res1.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var Response = Res1.Content.ReadAsStringAsync().Result;
                    experiences = JsonConvert.DeserializeObject<List<Experience>>(Response);
                }
                if (Res2.IsSuccessStatusCode)
                {
                    var Response = Res2.Content.ReadAsStringAsync().Result;
                    projects = JsonConvert.DeserializeObject<List<Project>>(Response);
                }
                if (Res3.IsSuccessStatusCode)
                {
                    var Response = Res3.Content.ReadAsStringAsync().Result;
                    skills = JsonConvert.DeserializeObject<List<Skill>>(Response);
                }
                if (Res4.IsSuccessStatusCode)
                {
                    var Response = Res4.Content.ReadAsStringAsync().Result;
                    frameworkNames = JsonConvert.DeserializeObject<List<Framework>>(Response);
                }
                if (Res5.IsSuccessStatusCode)
                {
                    var Response = Res5.Content.ReadAsStringAsync().Result;
                    organizations = JsonConvert.DeserializeObject<List<Organization>>(Response);
                }
                if (Res6.IsSuccessStatusCode)
                {
                    var Response = Res6.Content.ReadAsStringAsync().Result;
                    domains = JsonConvert.DeserializeObject<List<Domain>>(Response);
                }

                studentVM.skills = skills;
                studentVM.projects = projects;
                studentVM.experiences = experiences;
                studentVM.frameworkNames = frameworkNames;
                studentVM.organizationNames = organizations;
                studentVM.domains = domains;

                return View(studentVM);
            }
            //return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult DeleteProject(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("studentProfile/DeleteProject/" + id);
                //deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExp(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("studentProfile/DeleteExperience/" + id);
                //deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

    }
}