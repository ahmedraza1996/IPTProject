using IptProject.Models.Cafeteria;
using IptProject.Models.TimeTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
namespace IptProject.Controllers
{
    public class TimeTableController : Controller
    {
        public static List<TimeTableData> timetable = GetTimetable();
        public static List<string> BatchList = timetable.Select(x=> x.batch).Distinct().ToList();
        public static List<int> Daylist = timetable.Select(x => x.day).Distinct().ToList();
        public static List<string> Courselist = timetable.Select(x => x.course).Distinct().ToList();
        public static List<string> Sectionlist = timetable.Select(x => x.section).Distinct().ToList();
        public static List<string> Instructorlist = timetable.Select(x => x.empname).Distinct().ToList();
        // GET: Cafeteria
        public ActionResult GetProduct()
        {
            List<FoodItem> lstFoodItems = new List<FoodItem>();
            


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44380/api/");
                //HTTP GET
                var responseTask = client.GetAsync("cafeteria/getproduct");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<FoodItem[]>();
                    readTask.Wait();

                    var fooditems = readTask.Result;

                    foreach (var item in fooditems)
                    {
                        lstFoodItems.Add(item);
                    }
                }
            }

            return View(lstFoodItems);
        }
        
        public static List<TimeTableData> GetTimetable()
        {
            List<TimeTableData> temp = new List<TimeTableData>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44380/api/");
                var responseTask = client.GetAsync("timetable/fetchtimetable");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<TimeTableData[]>();
                   
                    readTask.Wait();

                    var fooditems = readTask.Result;

                    foreach (var item in fooditems)
                    {
                        temp.Add(item);
                    }
                }
            }
            return temp;
        }
        public ActionResult BatchDropDown()
        {
            
            
            ViewBag.BatchList = BatchList;

            
            return View();
        }
        [HttpGet]
        public ActionResult GetClassTimeTable(string query1,string query2,string query3)
        {
            timetable.Clear();
            timetable = GetTimetable();

            ViewBag.BatchList = BatchList;
            ViewBag.DayList = Daylist;
            ViewBag.SectionList = Sectionlist;

            List<TimeTableData> batchtimetable = new List<TimeTableData>();
            if (string.IsNullOrEmpty(query1))
            {
               batchtimetable= timetable.Where(x=> x.day == Convert.ToInt32(query2)).ToList();
            }
            else if (string.IsNullOrEmpty(query2))
            {
               batchtimetable= timetable.Where(x => x.batch == query1).ToList();
            }
            else if (string.IsNullOrEmpty(query3))
            {
                batchtimetable = timetable.Where(x => x.batch == query2).ToList();
            }

            else
            {
                batchtimetable  = timetable.Where(x => x.batch == query1 && x.section == query3 && x.day == Convert.ToInt32(query2)).ToList();
            }
              

            return View(batchtimetable);
        }
        public ActionResult GetClassTimeTablereallocate(string courselist, string daylist, string sectionlist)
        {
            ViewBag.BatchList = BatchList;
            ViewBag.DayList = Daylist;
            ViewBag.SectionList = Sectionlist;
            
            courselist = courselist.Replace('_', ' ');
            List<TimeTableModel> batchtimetable = new List<TimeTableModel>();
            List<TimeTableModel> temp = new List<TimeTableModel>();
            Dictionary<string, object> data = new Dictionary<string, object>();

            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44380/api/");
                var responseTask = client.GetAsync("timetable/reallocateclassroom/?course="+courselist+"&Section="+sectionlist+"&day="+daylist+"");

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                }
            }


            return View(batchtimetable);
        }

        public ActionResult Reallocate()
        {


            ViewBag.BatchList = BatchList;
            for (int i = 0; i < Courselist.Count; i++)
            {
                Courselist[i] = Courselist[i].Replace(' ', '_');
            }

            ViewBag.Courselist =Courselist;
            ViewBag.DayList = Daylist;
            ViewBag.SectionList = Sectionlist;
            


            return View();
        }

        public ActionResult ExtraClass()
        {


            ViewBag.BatchList = BatchList;
            for (int i = 0; i < Courselist.Count; i++)
            {
                Courselist[i] = Courselist[i].Replace(' ', '_');
            }
            ViewBag.Courselist = Courselist;
            ViewBag.DayList = Daylist;
            ViewBag.SectionList = Sectionlist;
            for(int i=0;i<Instructorlist.Count;i++)
            {
                Instructorlist[i] = Instructorlist[i].Replace(' ', '_');
            }
            ViewBag.InstructorList = Instructorlist;


            return View();
        }
        [HttpPost]
        public ActionResult PostExtraClass(string courselist, string daylist, string sectionlist, string instructor)
        {
            ViewBag.BatchList = BatchList;
            ViewBag.DayList = Daylist;
            ViewBag.SectionList = Sectionlist;
            instructor = instructor.Replace('_', ' ');
            courselist = courselist.Replace('_', ' ');
            List<TimeTableModel> batchtimetable = new List<TimeTableModel>();
            List<TimeTableModel> temp = new List<TimeTableModel>();
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["courselist"] = courselist;
            data["daylist"] = daylist;
            data["sectionlist"] = sectionlist;
            data["instructor"] = instructor;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44380/api/");
                var responseTask = client.GetAsync("timetable/extraclass/?course=" + courselist + "&Section="+sectionlist+"&day="+daylist+"&instructor="+instructor+"");

                

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                }
            }
            GetTimetable();

            return View(batchtimetable);
        }


    }
}
