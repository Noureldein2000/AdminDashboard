using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateAccountCommissionViewModel
    {
        public int AccountId { get; set; }
        [Required]
        public int CommissionId { get; set; }
        public int ServiceId { get; set; }
        [Required]
        public int DenominationId { get; set; }
        public List<SelectListItem> Commissions { get; set; }
        public List<SelectListItem> Services { get; set; }
    }
}
