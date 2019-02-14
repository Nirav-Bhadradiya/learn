using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using BussinessEntities;
using BussinessLayers;
using MvcApplication2.Filters;
using MvcApplication2.ViewModels;

namespace MvcApplication2.Controllers
{
    public class BulkUploadController : AsyncController
    {
        //
        // GET: /BulkUploadController/

        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }


        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AdminFilter]
        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {
            var t1 = Thread.CurrentThread.ManagedThreadId;
            var employees = await Task.Factory.StartNew
                (() => GetEmployees(model));
            var t2 = Thread.CurrentThread.ManagedThreadId;
            var bal = new EmployeeBusinessLayer();
            bal.UploadEmployees(employees);
            return RedirectToAction("Index", "Employee");
        }


        /// <summary>
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<Employee> GetEmployees(FileUploadViewModel model)
        {
            var employees = new List<Employee>();
            var csvreader = new StreamReader(model.fileUpload.InputStream);
            csvreader.ReadLine(); // Assuming first line is header
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                if (line != null)
                {
                    var values = line.Split(','); //Values are comma separated

                    var e = new Employee
                    {
                        FirstName = values[0],
                        LastName = values[1],
                        Salary = int.Parse(values[2])
                    };
                    employees.Add(e);
                }
            }
            return employees;
        }
    }
}