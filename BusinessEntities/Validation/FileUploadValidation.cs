using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace BusinessEntities.Validation
{
    public class FileUploadValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            HttpPostedFileBase originalStream = value as HttpPostedFileBase;

            if (originalStream != null)
            {
                List<Employee> employees = new List<Employee>();
                StreamReader csvreader = new StreamReader(originalStream.InputStream);
                ValidationResult result = new ValidationResult(string.Empty);

                while (!csvreader.EndOfStream)
                {
                    var line = csvreader.ReadLine();
                    var values = line.Split(',');//Values are comma separated
                    FirstNameValidation firstNameValidation = new FirstNameValidation();
                    SalaryValidation salaryValidation = new SalaryValidation();
                    if (!firstNameValidation.IsValid(values[0]) || !salaryValidation.IsValid(values[2]))
                    {
                        originalStream.InputStream.Position = 0;
                        return new ValidationResult("Import failed, occur errors.");
                    }
                }
            }
            originalStream.InputStream.Position = 0;
            return ValidationResult.Success;
        }
    }
}