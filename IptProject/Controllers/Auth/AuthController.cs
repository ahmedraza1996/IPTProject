using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers.Auth
{
    public class AuthController : Controller
    {
        public bool StudentSessionExist()
        {
            if (Session[Shared.Constants.SESSION_STUDENT] == null)
            {

                return false;
            }
            else
                return true;
        }
        public bool FacultySessionExist()
        {
            if (Session[Shared.Constants.SESSION_FACULTY] == null)
            {

                return false;
            }
            else
                return true;
        }
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentHome()
        {
            if (!StudentSessionExist())
            {
                return RedirectToAction("StudentLogin", "Auth");
            }
            return View();
        }
        public ActionResult FacultyHome()
        {
            if (!FacultySessionExist())
            {
                return RedirectToAction("FacultyLogin", "Auth");
            }
            return View();
        }
        public ActionResult StudentLogin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult StudentLogin(string username, string password)
        {
            //FoodItem obj = new FoodItem();
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Cred"] = username;
            data["SPassword"] = password;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.PostAsJsonAsync("admin_student/Login", data);

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Dictionary<string, object>>();
                    readTask.Wait();

                    Dictionary<string, object> dta = readTask.Result;
                    SetSessionStudent(dta);


                    return Content("LoginSuccessful");


                }
                else
                {
                    var readTask = result.Content.ReadAsAsync<string>();
                    readTask.Wait();
                    string msg = readTask.Result;
                    return Content(msg);
                }
            }

            ////SelectList ItemStatus = Shared.Constants.getItemStatus();
            ////ViewBag.ItemStatus = ItemStatus;
            //return PartialView(obj);
        }
        public ActionResult FacultyLogin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult FacultyLogin(string username, string password)
        {
            //FoodItem obj = new FoodItem();
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["Cred"] = username;
            data["SPassword"] = password;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.PostAsJsonAsync("admin_faculty/Login", data);

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Dictionary<string, object>>();
                    readTask.Wait();

                    Dictionary<string, object> dta = readTask.Result;
                    SetSessionFaculty(dta);


                    return Content("LoginSuccessful");


                }
                else
                {
                    var readTask = result.Content.ReadAsAsync<string>();
                    readTask.Wait();
                    string msg = readTask.Result;
                    return Content(msg);
                }
            }

            ////SelectList ItemStatus = Shared.Constants.getItemStatus();
            ////ViewBag.ItemStatus = ItemStatus;
            //return PartialView(obj);
        }

        public Dictionary<string, object> GetSessionFaculty()
        {
            if (Session[Shared.Constants.SESSION_FACULTY] != null)
            {
                return Session[Shared.Constants.SESSION_FACULTY] as Dictionary<string, object>;
            }

            return null;
        }
        public void SetSessionFaculty(Dictionary<string, object> obj)
        {
            Session[Shared.Constants.SESSION_FACULTY] = obj;
        }

        public  void SetSessionStudent(Dictionary<string, object> obj)
        {
            Session[Shared.Constants.SESSION_STUDENT] = obj;
        }
        public Dictionary<string, object> GetSessionStudent()
        {
            if (Session[Shared.Constants.SESSION_STUDENT] != null)
            {
                return Session[Shared.Constants.SESSION_STUDENT] as Dictionary<string, object>;
            }

            return null;
        }

      
    }
}