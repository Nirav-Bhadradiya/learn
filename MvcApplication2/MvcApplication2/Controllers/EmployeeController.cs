using MvcApplication2.Models;
using MvcApplication2.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Test/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            return "Hello World is old now. It&rsquo;s time for wassup bro ;)";
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var employeeListViewModel = new EmployeeListViewModel();

            var empBal = new EmployeeBusinessLayer();
            var employees = empBal.GetEmployees();

            var empViewModels = new List<EmployeeViewModel>();

            foreach (var emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel
                {
                    EmployeeName = emp.FirstName + " " + emp.LastName,
                    Salary = emp.Salary.ToString("C"),
                    SalaryColor = emp.Salary > 15000 ? "yellow" : "green"
                };


                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            //employeeListViewModel.UserName = "Admin";
            return View("Index", employeeListViewModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="btnSubmit"></param>
        /// <returns></returns>
        public ActionResult SaveEmployee(Employee e, string btnSubmit)
        {
            switch (btnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        var empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("CreateEmployee");
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

    }
}
