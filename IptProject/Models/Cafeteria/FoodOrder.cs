using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IptProject.Models.Cafeteria
{
    public class FoodOrder
    {
        public int OrderID { get; set; }
        public int Amount { get; set; }
        public DateTime OrderDate { get; set; }
        public string Datestr { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentMethod { get; set; }
        public int StudentID { get; set; }
        public DateTime  OrderTime { get; set; }
        public string Timestr { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }

    }
}