﻿using System.Web;
using System.Web.Mvc;

namespace IptProject
{
    public class FilterConfig2
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
