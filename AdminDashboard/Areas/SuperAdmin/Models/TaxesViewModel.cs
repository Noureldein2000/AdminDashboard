using AdminDashboard.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class TaxesViewModel
    {
        public int ID { get; set; }
        [Required]
        [EnumDataType(typeof(TaxType), ErrorMessage = "You Should choose a TaxType")]
        public TaxType TaxesTypeID { get; set; }
        public string TaxesTypeName { get; set; }
        public string TaxRange { get; set; }
        public decimal Taxes { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal AmountFrom { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal AmountTo { get; set; }
        [Required]
        [EnumDataType(typeof(PaymentMode), ErrorMessage = "You Should choose a Mode")]
        public PaymentMode PaymentModeID { get; set; }
        public int CreatedBy { get; set; }
        public string PaymentModeName { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Value { get; set; }
        public bool Status { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
