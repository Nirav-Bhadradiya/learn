﻿using System;
<<<<<<< 32d9abc822c052db022d491e907889fe53960eaf
using System.Collections.Generic;
using System.Web.Mvc;
using BussinessEntities;
using BussinessLayers;
using MvcApplication2.Filters;
using MvcApplication2.ViewModels;
=======
using MvcApplication2.Models;
using MvcApplication2.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcApplication2.Filters;
>>>>>>> Day-6, HeaderFooterfilters and Custom Layouts

namespace MvcApplication2.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Test/
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            return "Hello World is old now. It&rsquo;s time for wassup bro ;)";
        }


        /// <summary>
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HeaderFooterFilter]
        public ActionResult Index()
        {
            var employeeListViewModel = new EmployeeListViewModel
            {
<<<<<<< 32d9abc822c052db022d491e907889fe53960eaf
                UserName = User.Identity.Name
=======
                UserName = User.Identity.Name,
>>>>>>> Day-6, HeaderFooterfilters and Custom Layouts
                //FooterData = new FooterViewModel
                //{
                //    CompanyName = "StepByStepSchools",
                //    Year = DateTime.Now.Year.ToString()
                //}
            };

            var empBal = new EmployeeBusinessLayer();
            var employees = empBal.GetEmployees();

            var empViewModels = new List<EmployeeViewModel>();

            foreach (var emp in employees)
            {
                var empViewModel = new EmployeeViewModel
                {
                    EmployeeName = emp.FirstName + " " + emp.LastName,
                    Salary = emp.Salary.ToString(),
                    SalaryColor = emp.Salary > 15000 ? "yellow" : "green"
                };


                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            //employeeListViewModel.UserName = "Admin";
            return View("Index", employeeListViewModel);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            var employeeListViewModel = new CreateEmployeeViewModel
            {
                //FooterData = new FooterViewModel
                //{
                //    CompanyName = "StepByStepSchools",
                //    Year = DateTime.Now.Year.ToString()
                //},
                UserName = User.Identity.Name
            };
            //Can be set to dynamic value
            //New Line
            return View("CreateEmployee", employeeListViewModel);
        }


        /// <summary>
<<<<<<< 32d9abc822c052db022d491e907889fe53960eaf
=======
        /// 
>>>>>>> Day-6, HeaderFooterfilters and Custom Layouts
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAddNewLink()
        {
            return Convert.ToBoolean(Session["IsAdmin"]) ? (ActionResult) PartialView("AddNewLink") : new EmptyResult();
        }


        /// <summary>
        /// </summary>
        /// <param name="e"></param>
        /// <param name="btnSubmit"></param>
        /// <returns></returns>
        [AdminFilter]
        //[ValidateAntiForgeryToken]
        [HeaderFooterFilter]
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
                    var vm = new CreateEmployeeViewModel
                    {
<<<<<<< 32d9abc822c052db022d491e907889fe53960eaf
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Salary = e.Salary.HasValue ? e.Salary.ToString() : ModelState["Salary"].Value.AttemptedValue,
                        //FooterData = new FooterViewModel
                        //{
                        //    CompanyName = "StepByStepSchools",
                        //    Year = DateTime.Now.Year.ToString()
                        //},
                        UserName = User.Identity.Name
                    };

                    //Can be set to dynamic value
                    //New Line
                    return View("CreateEmployee", vm); // Day 4 Change - Passing e here
                case "Cancel":
                    return View("Index");
=======
                        var vm = new CreateEmployeeViewModel
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Salary = e.Salary.HasValue ? e.Salary.ToString() : ModelState["Salary"].Value.AttemptedValue,
                            //FooterData = new FooterViewModel
                            //{
                            //    CompanyName = "StepByStepSchools",
                            //    Year = DateTime.Now.Year.ToString()
                            //},
                            UserName = User.Identity.Name
                        };

                        //Can be set to dynamic value
                        //New Line
                        return View("CreateEmployee", vm); // Day 4 Change - Passing e here
                    }
>>>>>>> Day-6, HeaderFooterfilters and Custom Layouts
            }
            return new EmptyResult();
        }
    }
<<<<<<< 32d9abc822c052db022d491e907889fe53960eaf
}
=======
}

>>>>>>> Day-6, HeaderFooterfilters and Custom Layouts
