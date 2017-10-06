using FirstMVC.Utils.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace FirstMVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        [HeaderFooterFilter]
        public ActionResult Index()
        {
            return View(new BaseViewModel());
        }
    }
}