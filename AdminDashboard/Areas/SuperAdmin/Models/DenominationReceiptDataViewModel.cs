using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class DenominationReceiptDataViewModel
    {
        public int Id { get; set; }
        public int DenominationID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Disclaimer { get; set; }
        [Required]
        public string Footer { get; set; }
    }
}
