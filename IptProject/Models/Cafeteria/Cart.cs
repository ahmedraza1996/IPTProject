using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Cafeteria
{
    public class Cart
    {

        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        //public int StudentId { get; set; }
        //public string ItemImage { get; set; }

        //other vars
        public int SubTotal { get; set; }
        public int TotalAmount { get; set; }


    }
}