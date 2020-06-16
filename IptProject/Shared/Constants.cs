using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IptProject.Shared
{
    public class Constants
    {

        public static SelectList getItemStatus()
        {
            SelectList ItemStatus = new SelectList(
                 new List<SelectListItem>
                     {
                        new SelectListItem { Text = "Available", Value ="Available"},
                        new SelectListItem { Text = "Not Available", Value = "Not Available"}

                     }, "Value", "Text"
            );

            return ItemStatus;
        }
        public static SelectList getOrderStatus()
        {
            SelectList OrderStatus = new SelectList(
                 new List<SelectListItem>
                     {
                     new SelectListItem { Text = "Delievered", Value = "Delievered"},
                     new SelectListItem { Text = "Ready", Value = "Ready"},
                     new SelectListItem { Text = "Cancelled", Value = "Cancelled"}
                      //,
                      //new SelectListItem { Text = "Pending", Value ="Pending"}

                     }, "Value", "Text"
            );

            return OrderStatus;
        }


    }
}