using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class DenominationCommissionViewModel
    {
        public int Id { get; set; }
        public int CommissionId { get; set; }
        public double? CommissionValue { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
        public int CommissionTypeId { get; set; }
        public string CommissionTypeName { get; set; }
        public int DenominationId { get; set; }
        public decimal AmountFrom { get; set; }
        public decimal AmountTo { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
