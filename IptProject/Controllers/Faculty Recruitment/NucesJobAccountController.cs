using IptApis.Models.FacultyRecruitment;
using IptProject.Content.FacultyRecruitment.DbOperations;
using IptProject.Models.Faculty_Recruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IptProject.Controllers.Faculty_Recruitment
{
    public class NucesJobAccountController : Controller
    {
        LoginDb logindbhelper = null;
        CandidateDb candidatedbhelper = null;
        EmployeeDb employeedbhelper = null;
        public NucesJobAccountController()
        {
            logindbhelper = new LoginDb();
            candidatedbhelper = new CandidateDb();
            employeedbhelper = new EmployeeDb();
        }

      
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            if(ModelState.IsValid)
            {
                if(model.LoginAs=="Candidate")
                {
                    List<CandidateEmployee> candidatelist = candidatedbhelper.GetAllCandidates();
                    foreach (CandidateEmployee item in candidatelist)
                    {
                        if (item.Email == model.Username && item.Epassword == model.Password)
                        {
                            FormsAuthentication.SetAuthCookie(model.Username, false);
                            return RedirectToAction("Index", "NucesJob");
                        }
                    }
                    ViewBag.Issuccess = "Wrong UserName or Password";
                    return View();
                }
                else
                {
                    List<Employee> employeelist = employeedbhelper.GetAllEmployee();
                    foreach (Employee item in employeelist)
                    {
                        if (item.Email == model.Username && item.Epassword == model.Password)
                        {
                            FormsAuthentication.SetAuthCookie(model.Username, false);
                            return RedirectToAction("Index", "NucesJob");
                        }
                    }
                    ViewBag.Issuccess = "Wrong UserName or Password";
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Data");
                return View();
            }
        }
        public ActionResult SignUpCandidate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUpCandidate(CandidateEmployee candidate)
        {
            if(ModelState.IsValid)
            {
                int result = candidatedbhelper.AddCandidate(candidate);
                if (result>0)
                {
                    ViewBag.Issuccess = "Registered Successfully";
                    ModelState.Clear();
                    return View();
                    //return RedirectToAction("Login", "NucesJobAccount");
                }
                else
                {
                    ViewBag.Issuccess = "Problem Registering";
                    ModelState.Clear();
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid Data");
                return View();
            }
            
        }
        
    }
}