using AdminDashboard.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CommissionViewModel : IValidatableObject
    {
        public int ID { get; set; }
        [Required]
        [EnumDataType(typeof(CommissionType), ErrorMessage = "You Should choose a Commission Type")]
        public CommissionType CommissionTypeID { get; set; }
        public string CommissionTypeName { get; set; }
        public decimal Commission { get; set; }
        [Required]
        public decimal AmountFrom { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal AmountTo { get; set; }
        [Required]
        [EnumDataType(typeof(PaymentMode), ErrorMessage = "You Should choose a Payment Mode")]
        public PaymentMode PaymentModeID { get; set; }
        public int CreatedBy { get; set; }
        public string PaymentModeName { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Value { get; set; }
        public bool Status { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ConvertEmptyStringToNull = true, ApplyFormatInEditMode = true)]
        [Display(Name = "Start date")]
        public DateTime? StartDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "End date")]
        public DateTime? EndDate { get; set; }
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (StartDate < DateTime.Today)
            {
                errors.Add(new ValidationResult($"{nameof(StartDate)} needs to be higher or equal to today date.", new List<string> { nameof(EndDate) }));
            }
            if (EndDate.HasValue && EndDate < StartDate)
            {
                errors.Add(new ValidationResult($"{nameof(EndDate)} needs to be greater than {nameof(StartDate)}.", new List<string> { nameof(EndDate) }));
            }
            return errors;
        }
    }
}
