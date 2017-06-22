using System.Collections.Generic;

namespace MvcApplication2.Models
{
    public class EmployeeBusinessLayer
    {
        DynamoDbDemoService service;

        public EmployeeBusinessLayer()
        {
            service = new DynamoDbDemoService();
        }
        

        public List<Employee> GetEmployeesFromDD()
        {
            return service.GetEmployees();
        }

     
        public Employee SaveEmployeeDD(Employee e)
        {
            service.AddEmployee(e);
            return e;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public bool IsValidUser(UserDetails u)
        {
            return u.UserName == "Admin" && u.Password == "Admin";
        }
    }
}