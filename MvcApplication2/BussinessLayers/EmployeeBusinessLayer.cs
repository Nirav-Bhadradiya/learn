using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using BussinessEntities;
using MvcApplication2.DataAccessLayer;
using MvcApplication2.Models;

namespace BussinessLayers
{
    public class EmployeeBusinessLayer
    {
        SqlProviderServices a = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
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


        /// <summary>
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public UserStatus GetUserValidity(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            if (u.UserName == "Nirav" && u.Password == "Nirav")
            {
                return UserStatus.AuthentucatedUser;
            }
            return UserStatus.NonAuthenticatedUser;
        }

        /// <summary>
        /// </summary>
        /// <param name="employees"></param>
        public void UploadEmployees(List<Employee> employees)
        {
            var salesDal = new SalesErpdal();
            salesDal.Employees.AddRange(employees);
            salesDal.SaveChanges();
        }
    }
}