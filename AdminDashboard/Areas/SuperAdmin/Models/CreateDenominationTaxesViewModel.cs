using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateDenominationTaxesViewModel
    {
        public int Id { get; set; }
        [Required]
        public int TaxesId { get; set; }
        public int DenominationId { get; set; }
        public string DenominationId { get; set; }
        public List<SelectListItem> Taxes { get; set; }
    }
}
