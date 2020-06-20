using IptApis.Models.FacultyRecruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using IptProject.Content.FacultyRecruitment.DbOperations;


namespace IptProject.Controllers.Faculty_Recruitment
{
    public class NucesJobController : Controller
    {
        JobOpeningDb dbhelper = null;
        public NucesJobController()
        {
            dbhelper = new JobOpeningDb();
        }
        //Nuces Recruitment Main page
        public ActionResult Index()
        {
            return View();
        }


        //Get All Job Openings posted by the Employee
        
            //[Authorize(Roles ="candidate")]
        public ActionResult GetAllJobOpenings()
        {
            List<JobOpening> AllJobOpenings = dbhelper.GetAllJobs();
            return View(AllJobOpenings);
        }

        //[Authorize (Roles ="Department of Computer Science")]
        public ActionResult AddJobOpening()
        {
            var List = new List<string>();
            List<Designation>alldata= dbhelper.GetAllDesignations();
            foreach(Designation item in alldata)
            {
                List.Add(item.DesignationTitle);
            }
            var List1 = new List<string>();
            List<Department> alldata1 = dbhelper.GetAllDepartments();
            foreach (Department item in alldata1)
            {
                List1.Add(item.DepartmentName);
            }
            ViewBag.list = List;
            ViewBag.list1 = List1;
            return View();
        }

        [HttpPost]
        public ActionResult AddJobOpening(JobOpening job)
        {
            if(ModelState.IsValid)
            {
                int result = dbhelper.AddJob(job);
                if (result>0)
                {
                   ModelState.Clear();
                   ViewBag.Issuccess = "Data Added Successfully";
                    var List = new List<string>();
                    List<Designation> alldata = dbhelper.GetAllDesignations();
                    foreach (Designation item in alldata)
                    {
                        List.Add(item.DesignationTitle);
                    }
                    var List1 = new List<string>();
                    List<Department> alldata1 = dbhelper.GetAllDepartments();
                    foreach (Department item in alldata1)
                    {
                        List1.Add(item.DepartmentName);
                    }
                    ViewBag.list = List;
                    ViewBag.list1 = List1;
                    return View();
                }
                else
                {
                   ModelState.Clear();
                   ViewBag.Issuccess = "Some problem adding the data";
                    var List = new List<string>();
                    List<Designation> alldata = dbhelper.GetAllDesignations();
                    foreach (Designation item in alldata)
                    {
                        List.Add(item.DesignationTitle);
                    }
                    var List1 = new List<string>();
                    List<Department> alldata1 = dbhelper.GetAllDepartments();
                    foreach (Department item in alldata1)
                    {
                        List1.Add(item.DepartmentName);
                    }
                    ViewBag.list = List;
                    ViewBag.list1 = List1;
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Data");
                var List = new List<string>();
                List<Designation> alldata = dbhelper.GetAllDesignations();
                foreach (Designation item in alldata)
                {
                    List.Add(item.DesignationTitle);
                }
                var List1 = new List<string>();
                List<Department> alldata1 = dbhelper.GetAllDepartments();
                foreach (Department item in alldata1)
                {
                    List1.Add(item.DepartmentName);
                }
                ViewBag.list = List;
                ViewBag.list1 = List1;
                return View();
            }
        }

        [HttpGet]
        //[Authorize(Roles = "Department of Computer Science")]
        public ActionResult JobOpeningDetails()
        {
            List<JobOpening> AllJobOpenings = dbhelper.GetAllJobs();
            ModelState.Clear();
            return View(AllJobOpenings);
        }

        [HttpPost]
        public ActionResult JobOpeningDetails(FormCollection formCollection)
        {
            if (Request.Form["ID"] != null)
            {
                string[] ids = Request.Form["ID"].Split(new char[] { ',' });
                foreach (string id in ids)
                {
                    dbhelper.DeleteJob(int.Parse(id));
                }
                var result = dbhelper.GetAllJobs();
                return View(result);
            }
            else
            {
                var result = dbhelper.GetAllJobs();
                ModelState.AddModelError("", "No Jobs Selected!");
                return View(result);
            }

        }
        [Authorize(Roles = "Department of Computer Science")]
        public ActionResult EditJobOpenings(int id)
        {
            var List = new List<string>();
            List<Designation> alldata = dbhelper.GetAllDesignations();
            foreach (Designation item in alldata)
            {
                List.Add(item.DesignationTitle);
            }
            var List1 = new List<string>();
            List<Department> alldata1 = dbhelper.GetAllDepartments();
            foreach (Department item in alldata1)
            {
                List1.Add(item.DepartmentName);
            }
            ViewBag.list = List;
            ViewBag.list1 = List1;
            JobOpening job = dbhelper.GetJobById(id);
            ViewBag.Designation = dbhelper.GetDesignationByID(job.DesignationID);
            ViewBag.Department = dbhelper.GetDepartmentByID(job.DepartmentID);
            return View(job);
        }

        [HttpPost]
        public ActionResult EditJobOpenings(JobOpening job)
        {
            if (ModelState.IsValid)
            {
                int result = dbhelper.UpdateJob(job);
                    if (result>0)
                    {
                        //ModelState.Clear();
                        ViewBag.Issuccess = "Data Updated Successfully";
                        return RedirectToAction("JobOpeningDetails");
                    }
                    else
                    {
                    //ModelState.Clear();
                    var List = new List<string>();
                    List<Designation> alldata = dbhelper.GetAllDesignations();
                    foreach (Designation item in alldata)
                    {
                        List.Add(item.DesignationTitle);
                    }
                    var List1 = new List<string>();
                    List<Department> alldata1 = dbhelper.GetAllDepartments();
                    foreach (Department item in alldata1)
                    {
                        List1.Add(item.DepartmentName);
                    }
                    ViewBag.list = List;
                    ViewBag.list1 = List1;
                    ViewBag.Issuccess = "Some problem updating the data";
                        return View(dbhelper.GetJobById(job.JobID));
                    }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Data");
                var List = new List<string>();
                List<Designation> alldata = dbhelper.GetAllDesignations();
                foreach (Designation item in alldata)
                {
                    List.Add(item.DesignationTitle);
                }
                var List1 = new List<string>();
                List<Department> alldata1 = dbhelper.GetAllDepartments();
                foreach (Department item in alldata1)
                {
                    List1.Add(item.DepartmentName);
                }
                ViewBag.list = List;
                ViewBag.list1 = List1;
                
                return View();

                
            }
        }
    }
}