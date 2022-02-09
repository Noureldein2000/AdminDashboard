using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateDenominationCommissionViewModel
    {
        public int Id { get; set; }
        [Required]
        public int CommissionId { get; set; }
        public int DenominationId { get; set; }
        public string DenominationName { get; set; }
        public List<SelectListItem> Commissions{ get; set; }
    }
}
