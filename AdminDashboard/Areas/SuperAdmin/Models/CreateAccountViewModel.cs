using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
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
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Mobile number not correct")]
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
        public int? AccountTypeID { get; set; }
        [Required]
        public List<int?> BalanceTypeId { get; set; }
        public int? AccountTypeProfileID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        [Required]
        public string Username { get; set; }
        public string UserEmail { get; set; }
        [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Mobile number not correct")]
        public string MobileAccountOwner { get; set; }
        //[Required, DataType(DataType.Password)]
        //public string Password { get; set; }
        //[Required, Compare("Password"), DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }
        //[EnumDataType(typeof(Roles), ErrorMessage = "You must choose a role")]
        public Roles UserRole { get; set; }
        public List<SelectListItem> Activities { get; set; }
        public List<SelectListItem> Entities { get; set; }
        public List<SelectListItem> Governerates { get; set; }
        public List<SelectListItem> AccountTypes { get; set; }
        public List<SelectListItem> AccountTypeProfiles { get; set; }
        public List<SelectListItem> Regions { get; set; }
        public List<SelectListItem> BalanceTypes { get; set; }
        //public List<SelectListItem> ParentAccounts { get; set; }
        public ConsumerUser ConsumerUser { get; set; }
    }

    public class ConsumerUser
    {
        public string Username { get; set; }
        public string UserEmail { get; set; }
        public string Mobile { get; set; }
        //[EnumDataType(typeof(Roles), ErrorMessage = "You must choose a role")]
        public Roles UserRole { get; set; }
    }
}
