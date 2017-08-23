using FirstMVC.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Utils.Filters
{
    public class LoggerExceptionFilter : HandleErrorAttribute
    {
        Exception exception;

        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            exception = filterContext.Exception;

            // if the request is AJAX return JSON else view.
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                //Because its a exception raised after ajax invocation
                //Lets return Json
                filterContext.Result = new JsonResult()
                {
                    Data = exception.Message,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                //Normal Exception
                //So let it handle by its default ways.
                base.OnException(filterContext);
            }

            FileLogger logger = new FileLogger();
            logger.LogException(exception);

            //if want to get different of the request
            //var currentController = (string)filterContext.RouteData.Values["controller"];
            //var currentActionName = (string)filterContext.RouteData.Values["action"];
        }
    }
}