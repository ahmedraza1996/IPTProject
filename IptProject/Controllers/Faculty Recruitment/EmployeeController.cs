using IptApis.Models.FacultyRecruitment;
using IptProject.Content.FacultyRecruitment.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers.Faculty_Recruitment
{
    [Authorize(Roles ="HumanResource")]
    public class EmployeeController : Controller
    {
        EmployeeDb empdbhelper;
        JobOpeningDb dbhelper;

        public EmployeeController()
        {
            empdbhelper = new EmployeeDb();
            dbhelper = new JobOpeningDb();
        }

        public ActionResult AddEmployee()
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
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {

            if (ModelState.IsValid)
            {
                int result = empdbhelper.AddEmployee(emp);
                if (result > 0)
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
    }
}