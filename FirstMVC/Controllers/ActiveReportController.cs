using FirstMVC.Utils.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var dirPath = Assembly.GetExecutingAssembly().Location;
            dirPath = Path.GetDirectoryName(dirPath);
            var pp = Path.GetFullPath(Path.Combine(dirPath, "ActiveReports.ReportService.asmx"));

            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"JukeboxV2.0\JukeboxV2.0\Datos\ich will.mp3");

            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            var a = Path.Combine(basePath, "ActiveReports.ReportService.asmx");



            return View(new TestViewModel() { Path = pp });
        }
    }

    public class TestViewModel : BaseViewModel
    {
        public string Path { get; set; }
    }
}