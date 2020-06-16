using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Cafeteria
{
    public class OrderDetails
    {
        public int ODID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public string Itemname { get; set; }
    }
}