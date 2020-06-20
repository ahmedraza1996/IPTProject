using IptProject.Models.FYP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers
{
    public class FypController : Controller
    {
        //Home Pages
        public ActionResult TeacherLogin()
        {
            return View();
        }
        public ActionResult StudentLogin()
        {
            return View();
        }
        public ActionResult StudentHome()
        {
            return View();
        }

        public ActionResult TeacherHome()
        {
            return View();
        }
        public IEnumerable<StudentProposal> GetDetails(String title)
        {
            List<StudentProposal> StudentProposalItems = new List<StudentProposal>();
            List<FypResponse> details = new List<FypResponse>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                //HTTP GET
                var newResponseTask = client.GetAsync("fyp1get/GetFypDetailsByTitle?title=" + title);
                newResponseTask.Wait();
                var newResult = newResponseTask.Result;

                if (newResult.IsSuccessStatusCode)
                {

                    var readTask = newResult.Content.ReadAsAsync<FypResponse[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        details.Add(item);
                    }
                }
                int id = details[0].LeaderID;
                var responseTask = client.GetAsync("fyp1get/GetProposalDetails?id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentProposal[]>();
                    readTask.Wait();

                    var fooditems = readTask.Result;

                    foreach (var item in fooditems)
                    {
                        StudentProposalItems.Add(item);
                    }
                }
            }

            return StudentProposalItems;

        }
        public static string GlobalViewTitle = "";
        [HttpGet]
        public ActionResult ViewStudentProposalSupervisor(String title)
        {
            ViewBag.message = title;
            GlobalViewTitle = title;
            var model = new GlobalModel();
            model.IndexModels = GetDetails(title);

            return View(model);
        }

        [ActionName("ViewStudentProposalSupervisor")]
        [HttpPost]
        public ActionResult ViewStudentProposalSupervisor_Post(GlobalModel student)
        {
            string myTitle = GlobalViewTitle;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl() + "fyp1post /UpdateProposalSupervisor");

                student.IndexModels = GetDetails(myTitle);
                List<StudentProposal> getList = new List<StudentProposal>();


                getList = student.IndexModels.ToList();
                student.SearchModel.Abstract = getList[0].Abstract;
                //student.SearchModel.Comment = getList[0].Comment;
                student.SearchModel.SupervisorID = getList[0].SupervisorID;
                student.SearchModel.CoSupervisorID = getList[0].CoSupervisorID;
                student.SearchModel.LeaderID = getList[0].LeaderID;
                student.SearchModel.Member1ID = getList[0].Member1ID;
                student.SearchModel.Member2ID = getList[0].Member2ID;
                //student.SearchModel.Status = getList[0].Status;
                student.SearchModel.ProjectType = getList[0].ProjectType;
                student.SearchModel.ProjectTitle = getList[0].ProjectTitle;
                student.SearchModel.ProposalID = getList[0].ProposalID;

                //HTTP POST
                var postTask = client.PostAsJsonAsync<StudentProposal>("UpdateProposalSupervisor", student.SearchModel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("TeacherHome");
                }
            }
            return View();
        }

        //Student Proposal

        public ActionResult StudentProposal()
        {
            return View();

        }

        [HttpPost]
        public ActionResult StudentProposal(StudentProposal student)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl() + "fyp1post/addproposalstudent");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<StudentProposal>("addproposalstudent", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("StudentHome");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult SupervisorProposalCards()
        {

            List<StudentProposal> listProposals = new List<StudentProposal>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetProposalsNameSupervisor?id=1012");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentProposal[]>();
                    readTask.Wait();

                    var Proposals = readTask.Result;

                    foreach (var item in Proposals)
                    {
                        listProposals.Add(item);
                    }
                }
            }

            return View(listProposals);
        }

        [HttpGet]
        public ActionResult ViewStudentProposal()
        {
            List<StudentProposal> StudentProposalItems = new List<StudentProposal>();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetProposalDetails?id=163900");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentProposal[]>();
                    readTask.Wait();

                    var fooditems = readTask.Result;

                    foreach (var item in fooditems)
                    {
                        StudentProposalItems.Add(item);
                    }
                }
            }

            return View(StudentProposalItems);
        }

        //Defense Form

        [HttpGet]
        public ActionResult DefenseCards()
        {
            List<StudentDefense> list = new List<StudentDefense>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetFypNames?id=1012");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentDefense[]>();
                    readTask.Wait();

                    var fooditems = readTask.Result;

                    foreach (var item in fooditems)
                    {
                        list.Add(item);
                    }
                }
            }
            return View(list);
        }
        /*
        [HttpGet]
        public ActionResult ViewDefenseForm(string title)
        {
            List<StudentDefense> studentDefensesItems = new List<StudentDefense>();
            
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44380/api/");
                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetFypDetailsByTitle?title="+title);
                responseTask.Wait();

                ViewBag.message = title;

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentDefense[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        studentDefensesItems.Add(item);
                    }
                }
            }
            
            return View(studentDefensesItems);
        }
        */

        [HttpGet]
        public ActionResult ViewStudentDefense()
        {
            List<StudentDefense> studentDefensesItems = new List<StudentDefense>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                var responseTask = client.GetAsync("fyp1get/GetProposalEvaluations?id=163963");
                responseTask.Wait();

                //ViewBag.message = title;

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentDefense[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        studentDefensesItems.Add(item);
                    }
                }
            }

            return View(studentDefensesItems);
        }

        [HttpGet]
        public ActionResult ViewStudentFinal()
        {
            List<Fyp1FinalModel> studentFinalItems = new List<Fyp1FinalModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetFinalEvaluations?id=163900");
                responseTask.Wait();

                //ViewBag.message = title;

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Fyp1FinalModel[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        studentFinalItems.Add(item);
                    }
                }
            }
            return View(studentFinalItems);
        }
        //Fyp I Final Form

        [HttpGet]
        public ActionResult Fyp1FinalCards()
        {
            List<StudentDefense> list = new List<StudentDefense>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetFypNames?id=1012");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentDefense[]>();
                    readTask.Wait();

                    var fooditems = readTask.Result;

                    foreach (var item in fooditems)
                    {
                        list.Add(item);
                    }
                }
            }
            return View(list);
        }


        [HttpGet]
        public ActionResult ViewFyp1FinalForm_Student()
        {
            List<Fyp1FinalModel> studentEvaluationItems = new List<Fyp1FinalModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetFinalEvaluations?id=163900");
                responseTask.Wait();



                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Fyp1FinalModel[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        studentEvaluationItems.Add(item);
                    }
                }

                var newresponseTask = client.GetAsync("fyp1get/GetFyp1FinalMarks?id=163900");
                newresponseTask.Wait();

                var newResult = newresponseTask.Result;


                if (result.IsSuccessStatusCode)
                {

                    var readTask = newResult.Content.ReadAsAsync<int_model[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        studentEvaluationItems[0].leaderMarks = Convert.ToInt32(item.Marks);
                    }
                }
            }
            return View(studentEvaluationItems);
        }






        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ///
        //FYP 1 Defense POST/GET
        //---------------------------------------------------------------------------------------------------------------
        public IEnumerable<StudentDefense> GetDefenseDetails(String title)
        {
            List<StudentDefense> studentDefensesItems = new List<StudentDefense>();
            List<FypResponse> details = new List<FypResponse>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                //HTTP GET
                var newResponseTask = client.GetAsync("fyp1get/GetFypDetailsByTitle?title=" + title);
                newResponseTask.Wait();
                var newResult = newResponseTask.Result;

                if (newResult.IsSuccessStatusCode)
                {

                    var readTask = newResult.Content.ReadAsAsync<FypResponse[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        details.Add(item);
                    }
                }
                int id = details[0].LeaderID;
                var responseTask = client.GetAsync("fyp1get/GetProposalEvaluations?id=" + id);
                responseTask.Wait();

                //ViewBag.message = title;

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<StudentDefense[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        studentDefensesItems.Add(item);
                    }
                }
            }

            return studentDefensesItems;
        }
        public static string GlobalViewDefenseTitle = "";
        [HttpGet]
        public ActionResult ViewDefenseForm(String title)
        {
            ViewBag.message = title;
            GlobalViewDefenseTitle = title;
            var model = new GlobalDefense();
            model.IndexModels = GetDefenseDetails(title);
            return View(model);
        }
        [ActionName("ViewDefenseForm")]
        [HttpPost]
        public ActionResult ViewStudentDefense_Post(GlobalDefense globalDefense)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl() + "fyp1post /AddProposalEvaluationJury");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<StudentDefense>("AddProposalEvaluationJury", globalDefense.SearchModel);
                postTask.Wait();
                String myTitle = GlobalViewDefenseTitle;
                List<StudentDefense> list = new List<StudentDefense>();
                globalDefense.IndexModels = GetDefenseDetails(myTitle);
                list = globalDefense.IndexModels.ToList();

                //globalDefense.SearchModel.ChangesRecommeneded = list[0].ChangesRecommeneded;
                globalDefense.SearchModel.CoSupervisorID = list[0].CoSupervisorID;
                globalDefense.SearchModel.SupervisorEmpID = list[0].SupervisorEmpID;
                globalDefense.SearchModel.LeaderID = list[0].LeaderID;
                globalDefense.SearchModel.Member1ID = list[0].Member1ID;
                globalDefense.SearchModel.Member2ID = list[0].Member2ID;


                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("TeacherHome");
                }
            }
            return View();
        }
        //----------------------------------------------------------------------------------------------------------------

        //FYP 2 final POST/GET
        //----------------------------------------------------------------------------------------------------------------
        public static string GlobalViewFinalTitle;
        public IEnumerable<Fyp1FinalModel> GetFinalDetails(String title)
        {
            List<Fyp1FinalModel> studentFinalItems = new List<Fyp1FinalModel>();
            List<FypResponse> details = new List<FypResponse>();
            List<Deliverables> deliverables = new List<Deliverables>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                //HTTP GET
                var newResponseTask = client.GetAsync("fyp1get/GetFypDetailsByTitle?title=" + title);
                newResponseTask.Wait();
                var newResult = newResponseTask.Result;

                if (newResult.IsSuccessStatusCode)
                {

                    var readTask = newResult.Content.ReadAsAsync<FypResponse[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        details.Add(item);
                    }
                }
                int id = details[0].LeaderID;
                //--------------------------------------------------------------------------
                var deliverablesResponseTask = client.GetAsync("fyp1get/GetFypDeliverablesDetailsByTitle?title=" + title);
                deliverablesResponseTask.Wait();
                var deliverablesResult = deliverablesResponseTask.Result;

                if (deliverablesResult.IsSuccessStatusCode)
                {

                    var readDeliverables = deliverablesResult.Content.ReadAsAsync<Deliverables[]>();
                    readDeliverables.Wait();

                    var evaluationItems = readDeliverables.Result;

                    foreach (var item in evaluationItems)
                    {
                        deliverables.Add(item);
                    }
                }



                //--------------------------------------------------------------------------
                var responseTask = client.GetAsync("fyp1get/GetFinalEvaluations?id=" + id);
                responseTask.Wait();

                //ViewBag.message = title;

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Fyp1FinalModel[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        studentFinalItems.Add(item);
                    }
                    int i = 0;
                    foreach (var item in deliverables)
                    {
                        if (i == 0)
                        {
                            string myString1 = item.Deliverables1;
                            studentFinalItems[0].Deliverable1 = myString1;

                            myString1 = item.Deliverables2;
                            studentFinalItems[0].Deliverable2 = myString1;

                            myString1 = item.Deliverables3;
                            studentFinalItems[0].Deliverable3 = myString1;

                            myString1 = item.Deliverables4;
                            studentFinalItems[0].Deliverable4 = myString1;

                            myString1 = item.Deliverables5;
                            studentFinalItems[0].Deliverable5 = myString1;
                        }

                        /*string myString = item.
                        studentFinalItems.Add(item)*/
                    }
                }
            }

            return studentFinalItems;
        }
        [HttpGet]
        public ActionResult ViewFyp1FinalForm(String title)
        {
            ViewBag.message = title;
            GlobalViewFinalTitle = title;
            var model = new GlobalFinal();
            model.IndexModels = GetFinalDetails(title);
            return View(model);
        }
        [ActionName("ViewFyp1FinalForm")]
        [HttpPost]
        public ActionResult ViewFyp1FinalForm_Post(GlobalFinal globalFinal)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl() + "fyp1post/AddFinalEvaluationJury");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Fyp1FinalModel>("AddFinalEvaluationJury", globalFinal.SearchModel);
                postTask.Wait();
                String myTitle = GlobalViewFinalTitle;
                List<Fyp1FinalModel> list = new List<Fyp1FinalModel>();
                globalFinal.IndexModels = GetFinalDetails(myTitle);
                list = globalFinal.IndexModels.ToList();

                //globalDefense.SearchModel.ChangesRecommeneded = list[0].ChangesRecommeneded;
                //globalFinal.SearchModel.CoSupervisorID = list[0].CoSupervisorID;
                //globalFinal.SearchModel.SupervisorEmpID = list[0].SupervisorEmpID;

                //globalFinal.SearchModel.ProjectName = list[0].ProjectName;
                globalFinal.SearchModel.LeaderID = list[0].LeaderID;
                globalFinal.SearchModel.Member1ID = list[0].Member1ID;
                globalFinal.SearchModel.Member2ID = list[0].Member2ID;
                //globalFinal.SearchModel.CoSuperVisorID = list[0].CoSuperVisorID;
                //globalFinal.SearchModel.SuperVisorEmpID = list[0].SuperVisorEmpID;

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("TeacherHome");
                }
            }
            return View();
        }


        ////sara fyp 2
        public static int idfyp;


        /*_____________________________________FYP2 Mid Evaluation by Jury______________________________*/
        public IEnumerable<FYP2MidEvaluation> GetFyp2Mid(string title)
        {
            List<FYP2MidEvaluation> FYP2MidEvaluationItems = new List<FYP2MidEvaluation>();
            List<FypResponse> details = new List<FypResponse>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                var newResponseTask = client.GetAsync("fyp1get/GetFypDetailsByTitle?title=" + title);
                newResponseTask.Wait();
                var newResult = newResponseTask.Result;

                if (newResult.IsSuccessStatusCode)
                {

                    var readTask = newResult.Content.ReadAsAsync<FypResponse[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        details.Add(item);
                    }
                }
                int id = details[0].LeaderID;
                idfyp = details[0].FypID;
                //--------------------------------------------------------------------------
                //HTTP GET
                var responseTask = client.GetAsync("FYP2Get/GetMidEvaluationByID?id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<FYP2MidEvaluation[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        FYP2MidEvaluationItems.Add(item);
                    }
                }
            }
            return FYP2MidEvaluationItems;
        }
        public static string FYP2Mid;
        [HttpGet]
        public ActionResult ViewFYP2MidEvaluation(String title)
        {
            ViewBag.message = title;
            FYP2Mid = title;
            var model = new GlobalFyp2Mid();
            model.IndexModels = GetFyp2Mid(title);
            return View(model);

        }
        [ActionName("ViewFYP2MidEvaluation")]
        [HttpPost]
        public ActionResult ViewFyp2MidEvaluation_Post(GlobalFyp2Mid global)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl() + "fyp2post/AddMidEvaluationJury");

                //HTTP POST

                String myTitle = FYP2Mid;
                List<FYP2MidEvaluation> list = new List<FYP2MidEvaluation>();
                global.IndexModels = GetFyp2Mid(myTitle);
                list = global.IndexModels.ToList();

                global.SearchModel.LeaderID = list[0].LeaderID;
                global.SearchModel.Member1ID = list[0].Member1ID;
                global.SearchModel.Member2ID = list[0].Member2ID;
                global.SearchModel.Member2ID = list[0].Member2ID;
                global.SearchModel.FypID = idfyp;
                global.SearchModel.FormID = 3;
                global.SearchModel.Member2ID = list[0].Member2ID;
                var postTask = client.PostAsJsonAsync<FYP2MidEvaluation>("AddMidEvaluationJury", global.SearchModel);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("TeacherHome");
                }
            }
            return View();
        }

        /*_____________________________________FYP2 Final Evaluation by Jury______________________________*/
        public IEnumerable<FYP2FinalEvaluation> GetFyp2Final(string title)
        {
            List<FYP2FinalEvaluation> FYP2FinalEvaluationItems = new List<FYP2FinalEvaluation>();
            List<FypResponse> details = new List<FypResponse>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                var newResponseTask = client.GetAsync("fyp1get/GetFypDetailsByTitle?title=" + title);
                newResponseTask.Wait();
                var newResult = newResponseTask.Result;

                if (newResult.IsSuccessStatusCode)
                {

                    var readTask = newResult.Content.ReadAsAsync<FypResponse[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        details.Add(item);
                    }
                }
                int id = details[0].LeaderID;
                idfyp = details[0].FypID;
                //--------------------------------------------------------------------------
                //HTTP GET
                var responseTask = client.GetAsync("FYP2Get/GetFinalEvaluationByID?id=" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<FYP2FinalEvaluation[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        FYP2FinalEvaluationItems.Add(item);
                    }
                }
            }
            return FYP2FinalEvaluationItems;
        }
        public static string FYP2Final;

        [HttpGet]
        public ActionResult ViewFinalEvaluation(String title)
        {
            ViewBag.message = title;
            FYP2Final = title;
            var model = new GlobalFyp2Final();
            model.IndexModelsFinal = GetFyp2Final(title);
            return View(model);

        }
        [ActionName("ViewFinalEvaluation")]
        [HttpPost]
        public ActionResult ViewFinalEvaluation_Post(GlobalFyp2Final global)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl() + "fyp2post/AddFinalEvaluationJury");



                String myTitle = FYP2Final;
                List<FYP2FinalEvaluation> list = new List<FYP2FinalEvaluation>();
                global.IndexModelsFinal = GetFyp2Final(myTitle);
                list = global.IndexModelsFinal.ToList();

                global.SearchModelFinal.LeaderID = list[0].LeaderID;
                global.SearchModelFinal.Member1ID = list[0].Member1ID;
                global.SearchModelFinal.Member2ID = list[0].Member2ID;
                global.SearchModelFinal.FypID = idfyp;
                global.SearchModelFinal.FormID = 4;
                var postTask = client.PostAsJsonAsync<FYP2FinalEvaluation>("AddFinalEvaluationJury", global.SearchModelFinal);

                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("TeacherHome");
                }
            }
            return View();
        }
        /*______________________________________FYP-II FINAL EVALUATION BY INTERNAL JURY______________________________*/


        [HttpGet]
        public ActionResult InternalJuryEvaluation(String title)
        {
            ViewBag.message = title;
            FYP2Final = title;
            var model = new GlobalFyp2Final();
            model.IndexModelsFinal = GetFyp2Final(title);
            return View(model);

        }
        [ActionName("InternalJuryEvaluation")]
        [HttpPost]
        public ActionResult InternalJuryEvaluation_Post(GlobalFyp2Final global)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl() + "fyp2post/AddFyp2FinalEvaluationJury");



                String myTitle = FYP2Final;
                List<FYP2FinalEvaluation> list = new List<FYP2FinalEvaluation>();
                global.IndexModelsFinal = GetFyp2Final(myTitle);
                list = global.IndexModelsFinal.ToList();

                global.SearchModelFinal.LeaderID = list[0].LeaderID;
                global.SearchModelFinal.Member1ID = list[0].Member1ID;
                global.SearchModelFinal.Member2ID = list[0].Member2ID;
                global.SearchModelFinal.FypID = idfyp;
                global.SearchModelFinal.FormID = 5;
                var postTask = client.PostAsJsonAsync<FYP2FinalEvaluation>("AddFyp2ExternalEvaluationJury", global.SearchModelFinal);

                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("TeacherHome");
                }
            }
            return View();
        }



        /*_______________________________________FINAL PROJECT CARDS SUPERVISOR______________________________*/
        [HttpGet]
        public ActionResult FinalEvaluation()
        {
            List<FYP2FinalEvaluation> list = new List<FYP2FinalEvaluation>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetFypNames?id=1012");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<FYP2FinalEvaluation[]>();
                    readTask.Wait();

                    var fypitems = readTask.Result;

                    foreach (var item in fypitems)
                    {
                        list.Add(item);
                    }
                }
            }
            return View(list);
        }
        /*_______________________________________FINAL PROJECT CARDS INTERNAL JURY______________________________*/
        [HttpGet]
        public ActionResult InternalEvaluation()
        {
            List<FYP2FinalEvaluation> list = new List<FYP2FinalEvaluation>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetFypNames?id=1012");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<FYP2FinalEvaluation[]>();
                    readTask.Wait();

                    var fypitems = readTask.Result;

                    foreach (var item in fypitems)
                    {
                        list.Add(item);
                    }
                }
            }
            return View(list);
        }

        /*_______________________________________MID FYPII PROJECT CARDS______________________________*/
        [HttpGet]
        public ActionResult MidEvaluation()
        {
            List<FYP2MidEvaluation> list = new List<FYP2MidEvaluation>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                //HTTP GET
                var responseTask = client.GetAsync("fyp1get/GetFypNames?id=1012");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<FYP2MidEvaluation[]>();
                    readTask.Wait();

                    var fypitems = readTask.Result;

                    foreach (var item in fypitems)
                    {
                        list.Add(item);
                    }
                }
            }
            return View(list);
        }
        /*_______________________________________FINAL FYPII EVALUATION VIEW FOR STUDENTS______________________________*/
        [HttpGet]
        public ActionResult Evaluation()
        {
            List<FYP2FinalEvaluation> FYP2FinalEvaluationItems = new List<FYP2FinalEvaluation>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                var responseTask = client.GetAsync("FYP2Get/GetFinalEvaluationByID?id=163900");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<FYP2FinalEvaluation[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        FYP2FinalEvaluationItems.Add(item);
                    }
                }

                var responseTask1 = client.GetAsync("FYP2Get/GetFyp2FinalMarks?id=163900");
                responseTask1.Wait();

                var result1 = responseTask1.Result;
                if (result1.IsSuccessStatusCode)
                {

                    var readTask = result1.Content.ReadAsAsync<Marks_Model[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        FYP2FinalEvaluationItems[0].leaderMarks = Convert.ToInt32(item.Marks);
                    }
                }
                var responseTask2 = client.GetAsync("FYP2Get/GetFypExternalMarks?id=163900");
                responseTask2.Wait();

                var result2 = responseTask2.Result;
                if (result2.IsSuccessStatusCode)
                {

                    var readTask = result2.Content.ReadAsAsync<Marks_Model[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        FYP2FinalEvaluationItems[0].member1marks = Convert.ToInt32(item.Marks);
                    }
                }


            }

            return View(FYP2FinalEvaluationItems);
        }
        /*_______________________________________STUDENT VIEW: FYP2 MID EVALUATION______________________________*/
        [HttpGet]
        public ActionResult FYP2MidEvaluation()
        {
            List<FYP2MidEvaluation> FYP2MidEvaluationItems = new List<FYP2MidEvaluation>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());

                var responseTask = client.GetAsync("FYP2Get/GetMidEvaluationByID?id=163963");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<FYP2MidEvaluation[]>();
                    readTask.Wait();

                    var evaluationItems = readTask.Result;

                    foreach (var item in evaluationItems)
                    {
                        FYP2MidEvaluationItems.Add(item);
                    }
                }


            }
            return View(FYP2MidEvaluationItems);
        }

    }
}