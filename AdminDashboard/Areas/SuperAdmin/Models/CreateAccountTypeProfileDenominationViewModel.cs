using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateAccountTypeProfileDenominationViewModel
    {
        public int Id { get; set; }
        [Required]
        public int AccountTypeProfileID { get; set; }
        [Required]
        public int DenominationID { get; set; }
        public List<SelectListItem> Services { get; set; }
        public List<SelectListItem> AcountTypeProfiles { get; set; }
    }
}
