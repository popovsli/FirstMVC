using BusinessLayer;
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
            AreaRegistration.RegisterAllAreas();
            BusinessSettings.SetBusiness();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Add(new MyCustomViewEngine()); // reister custom view engine
            BundleTable.EnableOptimizations = true;
            //ModelBinders.Binders.Add(typeof(CustomModelBinder), new CustomModelBinder()); //register custom model binder
            //ModelBinders.Binders.DefaultBinder = new DropDownDateTimeBinder(); // register overriden model binder
        }
    }
}
