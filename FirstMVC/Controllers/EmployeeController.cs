using BusinessEntities;
using BusinessLayer;
using FirstMVC.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ViewModel;

namespace FirstMVC.Controllers
{
    //[Authorize] //At controller level
    public class EmployeeController : Controller
    {
        //[OutputCache(Duration = 15, Location = System.Web.UI.OutputCacheLocation.Any)]
        [HeaderFooterFilter]
        //[Authorize] //At Action level
        public ActionResult Index()
        {
            IPrincipal usr = System.Web.HttpContext.Current.User;

            //Get user Identity this work when using Windows authentication
            WindowsIdentity userIdentity = WindowsIdentity.GetCurrent();

            bool isAuthentication = Thread.CurrentPrincipal.Identity.IsAuthenticated;
            bool isAuthentication2 = System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            //Get user FormIdentity this work when using Form authentication
            FormsIdentity formIdentity = System.Web.HttpContext.Current.User.Identity as FormsIdentity;
            //Get data from session
            var session = this.Session[formIdentity.Ticket.UserData];

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString();
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;

            return View("Index", employeeListViewModel);
        }

        private void CheckUserRole()
        {
            string[] rolesForContentArray = new string[] { "test", "test2" };
            string[] userRolesArray = Roles.GetRolesForUser();
            //Get saved roles for View
            //string[] rolesForContentArray = DbContext.GetRolesForViewFromDb(thisViewName); 
            if (userRolesArray.Intersect(rolesForContentArray).Count() > 0)
            {
                // The user is authorized
            }
        }

        [AdminFilter]
        [HeaderFooterFilter]
        //Всички грешки от типа се визуализират от View
        //[HandleError(ExceptionType = typeof(System.IOException), View = "FileError")] 
        public ActionResult CreateEmployee()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        [HeaderFooterFilter]
        [AdminFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary.HasValue)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }

                        return View("CreateEmployee", vm); // Day 4 Change - Passing e here
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

        [ChildActionOnly]
        //[OutputCache(Duration = 60)]
        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }

        protected override void OnException(ExceptionContext exceptionContext)
        {
            if (exceptionContext.IsChildAction)
            {
                //we don't want to display the error screen if it is a child action,
                base.OnException(exceptionContext);
                return;
            }
            // log the exception in your configured logger
            //Logger.Log(exceptionContext.Exception);
            //handle when the app is not configured to use the custom error path
            if (!exceptionContext.HttpContext.IsCustomErrorEnabled)
            {
                exceptionContext.ExceptionHandled = true;
                this.View("ErrorManager").ExecuteResult(this.ControllerContext);
            }
        }

        public ActionResult M1()
        {
            TempData["a"] = "Value";
            //string s = TempData["a"].ToString();  // TempData will be available
            return RedirectToAction("M2");
        }

        [HeaderFooterFilter]
        public ActionResult M2()
        {
            //string s = TempData["a"].ToString(); //TempData will be available
            return View("CreateEmployee", new CreateEmployeeViewModel()); // TempData will be available inside view alsoJ
        }

        [HeaderFooterFilter]
        public ActionResult M3()
        {
            string s = TempData["a"].ToString();// TempData will be available
            return View("CreateEmployee", new CreateEmployeeViewModel()); // TempData will be available inside view alsoJ
        }



    }
}