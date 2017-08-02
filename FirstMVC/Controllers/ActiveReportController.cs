using FirstMVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace FirstMVC.Controllers
{
    [AllowAnonymous]
    public class ActiveReportController : Controller
    {
        // GET: ActiveReport
        [HeaderFooterFilter]
        public ActionResult Index()
        {
            return View(new BaseViewModel());
        }
    }
}