using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class UsersPermissionsViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<CheckBoxViewModel> UserClaims { get; set; }
    }
}
