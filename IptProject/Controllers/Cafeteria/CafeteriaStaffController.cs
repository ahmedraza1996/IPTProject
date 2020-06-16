using IptProject.Models.Cafeteria;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Controllers.Cafeteria
{
    public class CafeteriaStaffController : Controller
    {
        public static List<FoodOrder> lstOrder = new List<FoodOrder>();
        // GET: CafeteriaStaff
        public ActionResult Index()
        {
            return View();
        }
        //staff login
        //add product
        //view items
        //view all items
        //view not available items
        //get feedback
        //view order
        //getpending order by struden id
        // update order status
        // top up wallet
        //session
        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();

        }

        public ActionResult GetProductList()
        {
            List<FoodItem> lstFoodItems = new List<FoodItem>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.GetAsync("cafeteria/GetItems");
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
       
        [HttpPost]
        public ActionResult AddProduct(FoodItem foodItem)
        {
            string uri = Shared.ServerConfig.GetBaseUrl() + "CafeteriaStaff/AddProductWithImage";
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ItemName"] = foodItem.ItemName;
            data["Price"] = foodItem.Price;
            data["IDescription"] = foodItem.IDescription;
            data["ItemStatus"] = foodItem.ItemStatus;
            var files = Request.Files;
            var file = Request.Files[0];

            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {


                    var myContent = JsonConvert.SerializeObject(data);
                    var stringContent = new StringContent(myContent);
                    stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    content.Add(stringContent, "jsondata");
                    byte[] fileBytes = new byte[file.InputStream.Length + 1];
                    file.InputStream.Read(fileBytes, 0, fileBytes.Length);
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment") { FileName = file.FileName };
                    content.Add(fileContent);

                    var responseTask = client.PostAsync(uri, content);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.StatusCode == HttpStatusCode.Created)
                    {
                        ViewBag.resp = "Item Added Successfully!";
                        // return Content("Item Added Successfully!");

                    }
                    else if (result.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var readTask = result.Content.ReadAsAsync<Dictionary<string, string>>();
                        readTask.Wait();

                        Dictionary<string, string> resp = readTask.Result;
                        ViewBag.resp = "Error:" + resp["error"];


                        // return Content("Error:" + resp["error"]);
                    }
                    else
                    {
                        ViewBag.resp = "Err...There seems to be some error!";
                        //return Content("Err...There seems to be some error!");
                    }
                }

            }
            return View();
        }

        public ActionResult EditItemStatus(int ItemId)
        {
            FoodItem obj = new FoodItem();
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ItemID"] = ItemId;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.PostAsJsonAsync("cafeteria/GetItembyID", data);

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<FoodItem>();
                    readTask.Wait();

                    obj = readTask.Result;


                }
            }

            SelectList ItemStatus = Shared.Constants.getItemStatus();
            ViewBag.ItemStatus = ItemStatus;
            return PartialView(obj);
        }
        [HttpPost]
        public ActionResult EditItemStatus(FoodItem obj)
        {
            //FoodItem objFooditem = new FoodItem();
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["ItemId"] = obj.ItemId;
            data["ItemStatus"] = obj.ItemStatus;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Shared.ServerConfig.GetBaseUrl());
                //HTTP GET
                var responseTask = client.PostAsJsonAsync("CafeteriaStaff/EditItemStatus", data);

                responseTask.Wait();

                var result = responseTask.Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    return Content("Item Status Updated!");

                    //var readTask = result.Content.ReadAsAsync<FoodItem>();
                    //readTask.Wait();

                    //obj = readTask.Result;


                }
                else
                {
                    return Content("Err...There seems to be some error!");
                }
            }

            return Content("Err...There seems to be some error!");
        }

       

       

        public ActionResult TopUpWallet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TopUpWallet(Wallet obj)
        {
            return View();
        }
    }
}