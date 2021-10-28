using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateDenominationCommissionViewModel
    {
        public int Id { get; set; }
        public int CommissionId { get; set; }
        public int DenominationId { get; set; }
        public List<SelectListItem> Commissions{ get; set; }
    }
}
