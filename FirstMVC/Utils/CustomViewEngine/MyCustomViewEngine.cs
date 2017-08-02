using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.CustomViewEngine
{
    public class MyCustomViewEngine : VirtualPathProviderViewEngine
    {
        public MyCustomViewEngine()
        {
            this.ViewLocationFormats = new string[]
            { "~/Views/{1}/{2}.mytheme ", "~/Views/Shared/{2}.mytheme" };
            this.PartialViewLocationFormats = new string[]
            { "~/Views/{1}/{2}.mytheme ", "~/Views/Shared/{2}.mytheme " };
        }
        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var physicalpath =
            controllerContext.HttpContext.Server.MapPath(partialPath);
            //return new myCustomView(physicalpath);
            return null;
        }
        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(viewPath);
            //return new myCustomView(physicalpath);
            return null;
        }
    }
}