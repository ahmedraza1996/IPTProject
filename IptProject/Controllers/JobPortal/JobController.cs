using IptProject.Models.JobPortal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers
{
    public class JobController : Controller
    {
        // GET: Job/index
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                string Baseurl = "https://localhost:44380/";
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage allJobs = await client.GetAsync("api/jobs");
                List<Job> jobs = new List<Job>();
                //Job jobs = new Job();
                if (allJobs.IsSuccessStatusCode)
                {
                    var job = allJobs.Content.ReadAsStringAsync().Result;
                    jobs = JsonConvert.DeserializeObject<List<Job>>(job);
                    //jobs = JsonConvert.DeserializeObject<Job>(job);
                }
                return View(jobs);
            }
        }

        // GET: Job/index (Search)
        public ActionResult Search()
        {
            //using (var client = new HttpClient())
            //{
            //    string Baseurl = "https://localhost:44380/";
            //    client.BaseAddress = new Uri(Baseurl);

            //    client.DefaultRequestHeaders.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage allJobs = await client.GetAsync("api/jobs");
            //    List<Job> jobs = new List<Job>();
            //    //Job jobs = new Job();
            //    if (allJobs.IsSuccessStatusCode)
            //    {
            //        var job = allJobs.Content.ReadAsStringAsync().Result;
            //        jobs = JsonConvert.DeserializeObject<List<Job>>(job);
            //        //jobs = JsonConvert.DeserializeObject<Job>(job);
            //    }
            return View();
            //}
        }

        // url: job/detail
        public async System.Threading.Tasks.Task<ActionResult> Detail(int id)
        {
            using (var client = new HttpClient())
            {
                string Baseurl = "https://localhost:44380/";
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage allJobs = await client.GetAsync("api/job/detail/" + id.ToString());
                List<JobDetails> jobDetails = new List<JobDetails>();
                if (allJobs.IsSuccessStatusCode)
                {
                    var job = allJobs.Content.ReadAsStringAsync().Result;
                    jobDetails = JsonConvert.DeserializeObject<List<JobDetails>>(job);
                    //jobs = JsonConvert.DeserializeObject<Job>(job);
                }
                return View(jobDetails);
            }
        }

        public ActionResult ApplyNow()
        {
            return View();
        }

        public ActionResult AddJob()
        {
            using (var client = new HttpClient())
            {
                string Baseurl = "https://localhost:44380/";
                client.BaseAddress = new Uri(Baseurl);

                Job newjob = new Job { JobID = 1234, Title = "Senior Software Engineer", Designation = "C# Developer", ApplicationLink = "", Attachments = "", LastApplyDate = "8/2/2020", ContactPerson = "Rahim Khan", MinExperience = 5, Organization = "Arpatech" };
                var response = client.PostAsJsonAsync("api/addjob", newjob);
                return Content(response.Status.ToString());
            }
        }

    }
}