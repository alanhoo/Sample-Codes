using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Application : IValidatableObject
    {
        public int applicantId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Experiences { get; set; }
        public string Education { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Name))
            {
                errors.Add(new ValidationResult("Please enter a name",
                    new[] {"Name"})); 
            }
            if (string.IsNullOrEmpty(Email))
            {
                errors.Add(new ValidationResult("Please enter an email",
                    new[] { "Email" }));
            }
            if (string.IsNullOrEmpty(Phone))
            {
                errors.Add(new ValidationResult("Please enter a phone number",
                    new[] { "Phone" }));
            }
            if (string.IsNullOrEmpty(Address))
            {
                errors.Add(new ValidationResult("Please enter an address",
                    new[] { "Address" }));
            }
            if (string.IsNullOrEmpty(City))
            {
                errors.Add(new ValidationResult("Please enter a city",
                    new[] { "City" }));
            }
            if (string.IsNullOrEmpty(State))
            {
                errors.Add(new ValidationResult("Please enter a state",
                    new[] { "State" }));
            }
            if (string.IsNullOrEmpty(Zip))
            {
                errors.Add(new ValidationResult("Please enter a zip",
                    new[] { "Zip" }));
            }
            if (string.IsNullOrEmpty(Experiences))
            {
                errors.Add(new ValidationResult("Please enter your expeiences",
                    new[] { "Experiences" }));
            }
            if (string.IsNullOrEmpty(Education))
            {
                errors.Add(new ValidationResult("Please enter your education",
                    new[] { "Education" }));
            }
            return errors;
        } 
    }
}
