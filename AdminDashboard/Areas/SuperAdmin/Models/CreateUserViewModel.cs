using AdminDashboard.Models.SwaggerModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateUserViewModel
    {
        public int? AccountID { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, Compare("Password"), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [EnumDataType(typeof(Roles), ErrorMessage = "You must choose a role")]
        public Roles UserRole { get; set; }


    }
}
