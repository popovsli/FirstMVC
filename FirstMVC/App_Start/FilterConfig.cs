using FirstMVC.Filters;
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

            filters.Add(new AuthorizeAttribute());//Set autjentication globaly for hole app
        }
    }
}
