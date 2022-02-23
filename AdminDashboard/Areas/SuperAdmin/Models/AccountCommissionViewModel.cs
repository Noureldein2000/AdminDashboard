using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class AccountCommissionViewModel
    {
        public int Id { get; set; }
        public int CommissionId { get; set; }
        public int AccountId { get; set; }
        public double? From { get; set; }
        public double? To { get; set; }
        public double? CommissionValue { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentMode { get; set; }
        public int CommissionTypeId { get; set; }
        public string CommissionTypeName { get; set; }
        public int DenomiinationId { get; set; }
        public string DenominationFullName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
