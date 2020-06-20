using IptApis.Models.FacultyRecruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;


namespace IptProject.Content.FacultyRecruitment.DbOperations
{
    public class EmployeeDb
    {
        public List<Employee> GetAllEmployee()
        {
            List<Employee> AllEmployees = new List<Employee>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
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

    }
}