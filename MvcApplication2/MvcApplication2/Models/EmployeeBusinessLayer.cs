using System.Collections.Generic;
using System.Linq;
using MvcApplication2.DataAccessLayer;

namespace MvcApplication2.Models
{
    public class EmployeeBusinessLayer
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetEmployees()
        {
            var salesDal = new SalesErpdal();
            return salesDal.Employees.ToList();
        }


        /// <summary>
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public Employee SaveEmployee(Employee e)
        {
            var salesDal = new SalesErpdal();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
    }
}