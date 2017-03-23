using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessEntities.Validation
{
    public class SalaryValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please Provide Salary");
            }
            if (value != null && (Convert.ToInt32(value) < 5000 || Convert.ToInt32(value) > 50000))
            {
                return new ValidationResult("Put a proper Salary value between 5000 and 50000");
            }
            return ValidationResult.Success;
        }
    }
}