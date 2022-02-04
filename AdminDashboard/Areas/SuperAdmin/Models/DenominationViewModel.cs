using AdminDashboard.Helper;
using AdminDashboard.Models.SwaggerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class DenominationViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double Value { get; set; }
        public int ServiceID { get; set; }
        public int ServiceTypeID { get; set; }
        public string ServiceName { get; set; }
        public string OldDenominationID { get; set; }
        public bool Status { get; set; }
        [Required]
        [EnumDataType(typeof(Currency), ErrorMessage = "You Should choose a Currency")]
        public Currency CurrencyID { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double APIValue { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double MinValue { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double MaxValue { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Interval { get; set; }
        [Required]
        public int ServiceCategoryID { get; set; }
        [Required]
        [EnumDataType(typeof(DenominationClassType), ErrorMessage = "You Should choose a Class Type")]
        public DenominationClassType ClassType { get; set; }
        public bool Inquirable { get; set; }
        [Required]
        [EnumDataType(typeof(BillPaymentMode), ErrorMessage = "You Should choose a BillPayment Mode")]
        public BillPaymentMode BillPaymentModeID { get; set; }
        public string BillPaymentModeName { get; set; }
        [Required]
        [EnumDataType(typeof(PaymentMode), ErrorMessage = "You Should choose a Payment Mode")]
        public PaymentMode PaymentModeID { get; set; }
        public string PaymentModeName { get; set; }
    }
}
