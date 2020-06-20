using IptApis.Models.FacultyRecruitment;
using IptProject.Models.Faculty_Recruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace IptProject.Content.FacultyRecruitment.DbOperations
{
    public class LoginDb
    {
        public string[] GetRolesForUserName(string Email)
        {
            List<UserRole> AllUserRoles = new List<UserRole>();
            String[] Roles;
            string newemail = Email.Replace('.', '-');
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("NucesJobAccount/GetRolesbyUserName/" + newemail);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<UserRole[]>();
                    readTask.Wait();

                    var allopenings = readTask.Result;
                    foreach (var item in allopenings)
                    {
                        AllUserRoles.Add(item);
                    }
                    Roles = new string[AllUserRoles.Count];

                    int count = 0;
                    foreach (var users in AllUserRoles)
                    {
                        Roles[count] = users.Role;
                        count++;
                    }
                    return Roles;
                }
            }
            return null;
        }
    }
}