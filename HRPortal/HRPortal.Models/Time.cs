using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HRPortal.Models
{
    public class Time : IValidatableObject
    {
        public int Id { get; set; }

        public string EmpID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public decimal Hours { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(EmpID))
            {
                errors.Add(new ValidationResult("Please choose an Employee",
                    new[] { "EmpID" }));
            }

            if (string.IsNullOrEmpty(Date.ToString()))
            {
                errors.Add(new ValidationResult("Enter a date",
                    new[] { "Date" }));
            }

            if (DateTime.Compare(Date, DateTime.Today) > 0)
            {
                errors.Add(new ValidationResult("Enter a historical date",
                   new[] { "Date" }));
            }

            //if (string.IsNullOrEmpty(Hours.ToString()))
            if((int)Hours == 0 || string.IsNullOrEmpty(Hours.ToString()))
            {
                errors.Add(new ValidationResult("Enter the hours",
                    new[] { "Hours" }));
            }

            if (Hours > 16)
            {
                errors.Add(new ValidationResult("The hours worked must less than 16.",
                    new[] { "Hours" }));
            }

            return errors;

        }

    }
}
