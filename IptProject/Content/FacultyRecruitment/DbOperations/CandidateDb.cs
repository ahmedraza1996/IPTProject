using IptApis.Models.FacultyRecruitment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace IptProject.Content.FacultyRecruitment.DbOperations
{
    public class CandidateDb
    {

        public int AddCandidate(CandidateEmployee candidate)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["EName"] = candidate.EName;
            data["EAddress"] = candidate.EAddress;
            data["MobileNumber"] = candidate.MobileNumber;
            data["EducationLevel"] = candidate.EducationalLevel;
            data["ExperienceYears"] = candidate.ExperienceYears;
            data["CVpath"] = candidate.CVPath;
            data["Coverletterpath"] = candidate.CoverLetterPath;
            data["EPassword"] = candidate.Epassword;
            data["Email"] = candidate.Email;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                var responseTask = client.PostAsJsonAsync("Candidate/AddCandidate", data);
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

        public List<CandidateEmployee> GetAllCandidates()
        {
            List<CandidateEmployee> Allcandidates = new List<CandidateEmployee>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44380/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Candidate/GetAllCandidates");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<CandidateEmployee[]>();
                    readTask.Wait();

                    var allopenings = readTask.Result;

                    foreach (var item in allopenings)
                    {
                        
                        Allcandidates.Add(item);
                    }
                }
            }
            return Allcandidates;
        }
    }
}