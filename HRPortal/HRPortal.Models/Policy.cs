using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models
{
    public class Policy : IValidatableObject
    {
        public Category Category { get; set; }
        public string PolicyTitle { get; set; }
        public string ContentText { get; set; }

        public Policy()
        {
            Category = new Category();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Category.categoryName))
            {
                errors.Add(new ValidationResult("Please choose a Category",
                    new[] { "Category.categoryName" }));
            }

            if (string.IsNullOrEmpty(PolicyTitle))
            {
                errors.Add(new ValidationResult("Enter a title",
                    new[] { "PolicyTitle" }));
            }

            if (string.IsNullOrEmpty(ContentText))
            {
                errors.Add(new ValidationResult("Enter the policy content",
                    new[] { "ContentText" }));
            }

            return errors;

        }
    }
}
