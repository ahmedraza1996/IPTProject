using IptApis.Models.FacultyRecruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using IptProject.Content.FacultyRecruitment.DbOperations;


namespace IptProject.Content.FacultyRecruitment.DbOperations
{
    public class EmployeeDb
    {

        JobOpeningDb jobdbhelper;

        public EmployeeDb()
        {
            jobdbhelper = new JobOpeningDb();
        }
        public List<Employee> GetAllEmployee()
        {
            List<Employee> AllEmployees = new List<Employee>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("Employee/GetAllEmployees");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Employee[]>();
                    readTask.Wait();

                    var allopenings = readTask.Result;

                    foreach (var item in allopenings)
                    {

                        AllEmployees.Add(item);
                    }
                }
            }
            return AllEmployees;
        }

        public int AddEmployee(Employee emp)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["EmpName"] = emp.EmpName;
            data["Epassword"] = emp.Epassword;
            data["EMail"] = emp.Email;
            data["MobileNumber"]= emp.MobileNumber;
            data["DesignationID"] = jobdbhelper.GetDesignationIdbyTitle(emp.Designation);
            data["DepartmentID"] = jobdbhelper.GetDepartmentIdbyTitle(emp.Department);
            data["RefID"] = emp.RefID;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                var responseTask = client.PostAsJsonAsync("Employee/AddEmployee", data);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.StatusCode == HttpStatusCode.Created)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}