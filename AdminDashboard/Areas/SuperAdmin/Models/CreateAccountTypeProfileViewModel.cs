using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateAccountTypeProfileViewModel
    {
        public int Id { get; set; }
        [Required]
        public int AccountTypeID { get; set; }
        [Required]
        public int ProfileID { get; set; }
        public List<SelectListItem> AccountTypes{ get; set; }
        public List<SelectListItem> Profiles { get; set; }
    }
}
