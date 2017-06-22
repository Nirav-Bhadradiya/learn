using System.ComponentModel.DataAnnotations;
using MvcApplication2.Validations;
using Amazon.DynamoDBv2.DataModel;

namespace MvcApplication2.Models
{
    [DynamoDBTable("tblEmployee")]
    public class Employee
    {
        [Key]
        [DynamoDBHashKey]
        [DynamoDBProperty("iemp_id")]
        public int EmployeeId { get; set; }

        [FirstNameValidation]
        [DynamoDBProperty("FirstName")]
        public string FirstName { get; set; }

        [StringLength(5, ErrorMessage = "Last Name length should not be greater than 5")]
        public string LastName { get; set; }

        [DynamoDBProperty("Salary")]
        public int ? Salary { get; set; }
    }

}