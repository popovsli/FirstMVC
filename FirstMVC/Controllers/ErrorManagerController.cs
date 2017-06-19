using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVC.Controllers
{
    public class ErrorManagerController : Controller
    {
        // GET: ErrorManager
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ServerError()
        {
            return View();
        }
    }
}