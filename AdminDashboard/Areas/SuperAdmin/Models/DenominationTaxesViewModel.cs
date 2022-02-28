using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class DenominationTaxesViewModel
    {
        public int Id { get; set; }
        public int TaxId { get; set; }
        public decimal AmountFrom { get; set; }
        public decimal AmountTo { get; set; }
        public decimal TaxValue { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
        public int TaxTypeId { get; set; }
        public string TaxTypeName { get; set; }
        public int DenominationId { get; set; }
        public string Range { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
