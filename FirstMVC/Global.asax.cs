using BusinessLayer;
using FirstMVC.Controllers;
using FirstMVC.CustomModelBinders;
using FirstMVC.CustomViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FirstMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;

            BundleTable.EnableOptimizations = true;
            AreaRegistration.RegisterAllAreas();
            BusinessSettings.SetBusiness();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // reister custom view engine
            ViewEngines.Engines.Add(new MyCustomViewEngine());
            //ModelBinders.Binders.Add(typeof(CustomModelBinder), new CustomModelBinder()); //register custom model binder
            //ModelBinders.Binders.DefaultBinder = new DropDownDateTimeBinder(); // register overriden model binder
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            if (Server != null)
            {
                //Get the context
                HttpContext appContext = ((MvcApplication)sender).Context;
                Exception ex = Server.GetLastError().GetBaseException();
                //Log the error using the logging framework
                //Logger.Error(ex);
                //Clear the last error on the server so that custom errors are not fired
                Server.ClearError();
                //forward the user to the error manager controller.
                //IController errorController = new ErrorManagerController();
                //RouteData routeData = new RouteData();
                //routeData.Values["controller"] = "ErrorManagerController";
                //routeData.Values["action"] = "ServerError";
                //errorController.Execute(
                //new RequestContext(new HttpContextWrapper(appContext), routeData));
            }
        }

        //catch first chance exceptions
        protected void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            if (e.Exception is NotImplementedException)
            {
                // do something special when the functionality is not implemented
            }
        }
    }
}
