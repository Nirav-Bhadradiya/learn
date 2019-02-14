using System.ComponentModel.DataAnnotations;

namespace MvcApplication2.Validations
{
    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) // Checking for Empty Value
            {
                return new ValidationResult("Please Provide First Name");
            }
            return value.ToString().Contains("@") ? new ValidationResult("First Name should Not contain @") : ValidationResult.Success;
        }
    }
}