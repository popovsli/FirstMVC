using BusinessEntities;
using BusinessLayer;
using FirstMVC.Utils.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace FirstMVC.Controllers
{
    public class BulkUploadController : AsyncController
    {
        // GET: BulkUpload
        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult Index()
        {
            FileUploadViewModel fileUpload = new FileUploadViewModel();
            fileUpload.Employees = new List<EmployeeViewModel>();
            return View(fileUpload);
        }

        [HeaderFooterFilter]
        [AdminFilter]
        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {
            int t1 = Thread.CurrentThread.ManagedThreadId;

            List<Employee> employees = await Task.Factory.StartNew<List<Employee>>
            (() => GetEmployees(model));

            int t2 = Thread.CurrentThread.ManagedThreadId;

            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
                bal.UploadEmployees(employees);
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                FileUploadViewModel fileUpload = new FileUploadViewModel();
                List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();
                int rowCount = 0;
                foreach (Employee emp in employees)
                {
                    EmployeeViewModel empViewModel = new EmployeeViewModel();
                    empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                    empViewModel.Salary = emp.Salary.ToString();
                    empViewModel.RowCount = rowCount;
                    if (emp.Salary > 15000)
                    {
                        empViewModel.SalaryColor = "yellow";
                    }
                    else
                    {
                        empViewModel.SalaryColor = "green";
                    }
                    empViewModels.Add(empViewModel);
                    rowCount++;
                }
                fileUpload.Employees = empViewModels;
                return View("Index", fileUpload);
            }
        }

        private List<Employee> GetEmployees(FileUploadViewModel model)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader csvreader = new StreamReader(model.fileUpload.InputStream);
            int rowCount = 0;
            //csvreader.ReadLine(); // Assuming first line is header
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                var values = line.Split(',');//Values are comma separated
                Employee e = new Employee();
                e.FirstName = values[0];
                e.LastName = values[1];
                e.Salary = int.Parse(values[2]);
                TryValidateModel(e, rowCount.ToString());
                employees.Insert(rowCount, e);
                rowCount++;
            }
            return employees;
        }

    }
}