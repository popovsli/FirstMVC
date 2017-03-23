using BusinessEntities.Validation;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessEntities
{
    public class Employee 
    {
        [Key]
        public int EmployeeId { get; set; }

        [FirstNameValidation]
        public string FirstName { get; set; }

        [StringLength(15, ErrorMessage = "Last Name length should not be greater than 15")]
        public string LastName { get; set; }

        [SalaryValidation]
        public int? Salary { get; set; }

    }
}