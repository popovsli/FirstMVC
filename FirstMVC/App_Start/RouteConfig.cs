using FirstMVC.Utils.CustomRouteHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*allActiveReport}", new { allActiveReport = @".*\.ar11(/.*)?" });

            routes.MapMvcAttributeRoutes();

            //Register custom route handler
            //routes.MapRoute(
            //    name: "Home",
            //   url: "{controller}/{action}",
            //   defaults: new{controller = "Home",action = "Index"}).RouteHandler = new MyCustomRouteHandler();

            routes.MapRoute(
                name: "Upload",
                url: "Employee/BulkUpload",
                defaults: new { controller = "BulkUpload", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Employee", action = "Index", id = UrlParameter.Optional }
                );
        }
    }
}
