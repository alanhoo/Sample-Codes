using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HRPortalNew
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("Apply Route", "{controller}/{action}",
                new {controller = "Apply", action = "Form"});

            routes.MapRoute("Application Route", "{controller}/{action}",
                new {controller = "Home", action = "Index"});

            routes.MapRoute("Policy", "{controller}/{action}",
                new {controller = "Policy", action = "Index"});

            routes.MapRoute("Time", "{controller}/{action}",
               new { controller = "Time", action = "TimeForm" });

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
