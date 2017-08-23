using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace FirstMVC.Utils.Filters
{
    public class HeaderFooterFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewResult viewResult = filterContext.Result as ViewResult;
            if (viewResult != null) // v will null when v is not a ViewResult
            {
                BaseViewModel bvm = viewResult.Model as BaseViewModel;
                if (bvm != null)//bvm will be null when we want a view without Header and footer
                {
                    bvm.FooterData = new FooterViewModel();
                    bvm.HeaderData = new HeaderViewModel();
                    bvm.HeaderData.UserName = HttpContext.Current.User.Identity.Name;
                    bvm.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
                    bvm.FooterData.Year = DateTime.Now.Year.ToString();
                }
            }
        }
    }
}