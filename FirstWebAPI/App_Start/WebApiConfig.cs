using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace FirstWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SecondRoute",
                routeTemplate: "api/GetCustomerById/{id} ",
                defaults: new { controller = "Customer", action = "GetCustomerById" }
            );
            config.Routes.MapHttpRoute(
                name: "ThridRoute",
                routeTemplate: "api/{controller}/{action}"
            );//generic route like Asp.Net MVC

            config.Routes.MapHttpRoute(
              name: "DefaultApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional }
          );
        }
    }
}
