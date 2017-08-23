using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FirstMVC.Utils.Filters
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            FormsIdentity formIdentity = System.Web.HttpContext.Current.User.Identity as FormsIdentity;
            if (!Convert.ToBoolean(filterContext.HttpContext.Session[formIdentity.Ticket.UserData]))
            {
                filterContext.Result = new ContentResult()
                {
                    Content = "Unauthorized to access specified resource."
                };
            }
        }
    }
}