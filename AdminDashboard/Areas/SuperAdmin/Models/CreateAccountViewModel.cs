using AdminDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateAccountViewModel
    {
        public string OwnerName { get; set; }
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NationalID { get; set; }
        public string CommercialRegistrationNo { get; set; }
        public string TaxNo { get; set; }
        public int? ActivityID { get; set; }
        [Required]
        public int? EntityID { get; set; }
        [Required]
        public int? ParentAccountID { get; set; }
        [Required]
        public int? GovernerateID { get; set; }
        [Required]
        public int? RegionID { get; set; }
        [Required]
        public int? AccountTypeProfileID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<SelectListItem> Activities { get; set; }
        public List<SelectListItem> Entities { get; set; }
        public List<SelectListItem> Governerates { get; set; }
        public List<SelectListItem> AccountTypeProfiles { get; set; }
    }
}
