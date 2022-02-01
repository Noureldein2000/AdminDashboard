using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class AccountBalancesViewModel
    {
        public decimal TotalBalance { get; set; }
        public decimal TotalAvailableBalance { get; set; }
        public decimal Amount { get; set; }
        public string BalanceType { get; set; }
        [Required]
        public int BalanceTypeId { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
    }
}
