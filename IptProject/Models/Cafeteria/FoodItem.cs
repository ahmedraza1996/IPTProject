using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Cafeteria
{
    public class FoodItem
    {
        
        public FoodItem(int ItemId, string ItemName, string IDescription, string ItemStatus, int Price)
        {
            this.ItemId = ItemId;
            this.ItemName = ItemName;
            this.IDescription = IDescription;
            this.ItemStatus = ItemStatus;
            this.Price = Price;
        }
        public FoodItem()
        {

        }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string IDescription { get; set; }
        public string ItemStatus { get; set; }
        public int Price { get; set; }
        public string base64image { get; set; }
        public string ITEMIMAGE { get; set; }
        //IMAGE
        public HttpPostedFileBase IMAGEFILE { get; set; }


    }
}