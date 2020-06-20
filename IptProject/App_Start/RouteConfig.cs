using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IptProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Auth", action = "StudentLogin", id = UrlParameter.Optional }
        );
            routes.MapRoute(
               name: "FacultyLogin",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Auth", action = "FacultyLogin", id = UrlParameter.Optional }
           );
           
            routes.MapRoute(
             name: "CafeteriaLogin",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Cafeteria", action = "Index", id = UrlParameter.Optional }
         );
        }
    }
}
