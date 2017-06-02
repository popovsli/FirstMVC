using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.CustomActionResults
{
    public class CustomResult<T> : ActionResult
    {
        public T Data { private get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            // do work here
            string resultFromWork = "work that was done";
            context.HttpContext.Response.Write(resultFromWork);
        }
    }
}