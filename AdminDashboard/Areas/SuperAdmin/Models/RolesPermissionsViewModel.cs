using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class RolesPermissionsViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<CheckBoxViewModel> RoleClaims { get; set; }
    }
}
