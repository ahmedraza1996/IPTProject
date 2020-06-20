using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using IptProject.Models.adminpanel;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace IptProject.Controllers.adminpanel
{
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AdminPage(FormCollection formCollection)
        {
            adminVM adminVM = new adminVM();

            admininfo admininfo = new admininfo();
            admininfo adminL = new admininfo();

            string adminEmail = formCollection[1];
            string adminPassword = formCollection[2];

            admininfo.adminEmail = adminEmail;
            admininfo.adminPassword = adminPassword;

            var json = JsonConvert.SerializeObject(new adminVM { adminEmail = adminEmail, adminPassword = adminPassword });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage result = await client.PostAsync("admin/adminLogin/", data);
                var response = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(response);
                //adminL = JsonConvert.DeserializeObject<admininfo>(response);
                if (response == "null")
                {
                    //means login credentials were wrong
                    return View("AdminLogin");
                }
                else
                {
                    //adminVM.admininfos = adminL;
                    return View("Index");
                    //succeed logging in
                }
            }
        }











        //
        // Faculty CRUD Operations list starts here
        //
        public ActionResult FacultyDetails()
        {
            IEnumerable<faculties> empList;
            //List<faculties> empList = new List<faculties>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("admin/getFaculties/").Result;
                empList = response.Content.ReadAsAsync<IEnumerable<faculties>>().Result;


            }
            return View(empList);
        }

        [HttpGet]
        public async Task<ActionResult> AddOrEdit()
        {
            List<Designation> designations = new List<Designation>();
            //List<Department> departments = new List<Department>();

            AddDesVM addDesVM = new AddDesVM();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage result = await client.GetAsync("admin/getdesignation/");


                //HttpResponseMessage result1 = await client.GetAsync("admin/getdepartment/");

                if (result.IsSuccessStatusCode)
                {
                    var response = result.Content.ReadAsStringAsync().Result;
                    designations = JsonConvert.DeserializeObject<List<Designation>>(response);
                }

                /*if (result1.IsSuccessStatusCode)
                {
                    var response = result1.Content.ReadAsStringAsync().Result;
                    departments = JsonConvert.DeserializeObject<List<Department>>(response);
                }*/


                addDesVM.designations = designations;
                //addDesVM.departments = departments;
            }
            return View(addDesVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddFaculty(FormCollection formCollection)
        {
            string EmpName = formCollection[1];
            string Email = formCollection[2];
            string MobileNumber = formCollection[3];
            string EPassword = formCollection[4];
            string DesignationID = formCollection[5];
            string DepartmentID = formCollection[6];

            var json = JsonConvert.SerializeObject(new faculties { EmpName = EmpName, Email = Email, MobileNumber = MobileNumber, EPassword = EPassword, DesignationID = Int32.Parse(DesignationID), DepartmentID = Int32.Parse(DepartmentID) });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage result = await client.PostAsync("admin/AddFaculty/", data);

                var response = result.Content.ReadAsStringAsync().Result;


            }
            return View("Index");

        }

        /*[HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if(id==0)
            {
                return View(new faculties());
            }
            else
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44380/api/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync("admin/getFaculties/" + id.ToString()).Result;
                    return View(response.Content.ReadAsAsync<faculties>().Result);
                }
            }
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteFaculty(FormCollection formCollection)
        {
            string EmpID = formCollection[1];
            //int id = Int32.Parse(EmpID);

            var json = JsonConvert.SerializeObject(new faculties { EmpID = Int32.Parse(EmpID) });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage result = await client.PostAsync("admin/DeleteFaculty/", data);
                var response = result.Content.ReadAsStringAsync().Result;

                //TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }

        }











        //
        // Student CRUD Operations list starts here
        //
        public ActionResult StudentDetails()
        {
            IEnumerable<students> stdList;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("admin/getStudents/").Result;
                stdList = response.Content.ReadAsAsync<IEnumerable<students>>().Result;


            }
            return View(stdList);
        }



        [HttpGet]
        public async Task<ActionResult> StudentAddOrEdit()
        {
            List<Batch> batchs = new List<Batch>();
            //List<Department> departments = new List<Department>();

            AddBatchVM addBatchVM = new AddBatchVM();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage result = await client.GetAsync("admin/getBatch/");



                if (result.IsSuccessStatusCode)
                {
                    var response = result.Content.ReadAsStringAsync().Result;
                    batchs = JsonConvert.DeserializeObject<List<Batch>>(response);
                }

                /*if (result1.IsSuccessStatusCode)
                {
                    var response = result1.Content.ReadAsStringAsync().Result;
                    departments = JsonConvert.DeserializeObject<List<Department>>(response);
                }*/

                addBatchVM.batchs = batchs;
            }
            return View(addBatchVM);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddStudent(FormCollection formCollection)
        {
            string SName = formCollection[1];
            string Email = formCollection[2];
            string MobileNumber = formCollection[3];
            string RollNumber = formCollection[4];
            string SPassword = formCollection[5];
            string BatchID = formCollection[6];
            string ProgrammeID = formCollection[7];

            var json = JsonConvert.SerializeObject(new students { SName = SName, Email = Email, MobileNumber = MobileNumber, RollNumber = RollNumber, SPassword = SPassword, BatchID = Int32.Parse(BatchID), ProgrammeID = Int32.Parse(ProgrammeID) });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage result = await client.PostAsync("admin/AddStudent/", data);

                var response = result.Content.ReadAsStringAsync().Result;


            }
            return View("Index");

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteStudent(FormCollection formCollection)
        {
            string StudentID = formCollection[1];
            //int id = Int32.Parse(EmpID);

            var json = JsonConvert.SerializeObject(new students { StudentID = Int32.Parse(StudentID) });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage result = await client.PostAsync("admin/DeleteStudent/", data);
                var response = result.Content.ReadAsStringAsync().Result;

                //TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }

        }








        //
        // Courses CRUD Operations list starts here
        //
        public ActionResult CourseDetails()
        {
            IEnumerable<courses> crsList;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("admin/getCourses/").Result;
                crsList = response.Content.ReadAsAsync<IEnumerable<courses>>().Result;


            }
            return View(crsList);
        }



        [HttpGet]
        public ActionResult CourseAddOrEdit()
        {
            return View();

        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCourse(FormCollection formCollection)
        {
            string CourseName = formCollection[1];
            string CourseCode = formCollection[2];

            var json = JsonConvert.SerializeObject(new courses { CourseName = CourseName, CourseCode = CourseCode });
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage result = await client.PostAsync("admin/AddCourse/", data);

                var response = result.Content.ReadAsStringAsync().Result;


            }
            return View("Index");

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCourse(FormCollection formCollection)
        {
            string CourseID = formCollection[1];
            //int id = Int32.Parse(EmpID);

            var json = JsonConvert.SerializeObject(new courses { CourseID = Int32.Parse(CourseID) });
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (var client = new HttpClient())

            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage result = await client.PostAsync("admin/DeleteCourse/", data);
                var response = result.Content.ReadAsStringAsync().Result;

                //TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }

        }











    }
}