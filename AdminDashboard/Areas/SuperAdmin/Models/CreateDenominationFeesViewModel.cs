using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateDenominationFeesViewModel
    {
        public int Id { get; set; }
        [Required]
        public int FeesId { get; set; }
        public int DenominationId { get; set; }
        public List<SelectListItem> Fees { get; set; }
    }
}
