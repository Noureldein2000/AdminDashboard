using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class AccountTypeProfileViewModel
    {
        public int Id { get; set; }
        public int AccountTypeID { get; set; }
        public int ProfileID { get; set; }
        public string ProfileName { get; set; }
        public string AccountTypeName { get; set; }
        public string FullName { get; set; }
    }
}
