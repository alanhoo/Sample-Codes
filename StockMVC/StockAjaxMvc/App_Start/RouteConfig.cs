using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StockAjaxMvc
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Jquery", "Stock/GetQuote/{ID}",
                new {controller = "Stock", action = "GetQuote", id = UrlParameter.Optional});

            routes.MapRoute("Jquery2", "Stock/GetQuoteJson/{ID}",
                new { controller = "Stock", action = "GetQuoteJson", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
