﻿using FirstMVC.Utils.Filters;
using System;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());//ExceptionFilter
            filters.Add(new LoggerExceptionFilter());

            ////In that case we have to specify view name while attaching HandlError filter. 
            //filters.Add(new HandleErrorAttribute()
            //{
            //    View = "MyError",
            //    ExceptionType = typeof(ArgumentNullException)
            //}); 

            //Set autjentication globaly for hole app
            filters.Add(new AuthorizeAttribute());
            //Set globaly required HTTPS 
            //filters.Add(new RequireHttpsAttribute());
        }
    }
}
