using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class EditCommissionViewModel : CommissionViewModel
    {
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (EndDate.HasValue && EndDate < StartDate)
            {
                errors.Add(new ValidationResult($"{nameof(EndDate)} needs to be greater than {nameof(StartDate)}.", new List<string> { nameof(EndDate) }));
            }
            return errors;
        }
    }
}
