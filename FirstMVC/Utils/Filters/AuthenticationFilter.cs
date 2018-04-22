using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Utils.Filters
{
    public class AuthenticationFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var sessions = filterContext.HttpContext.Session["dd9ef9c3-3319-446c-9a86-ff23e79fa056"];
            base.OnAuthorization(filterContext);
        }
    }
}