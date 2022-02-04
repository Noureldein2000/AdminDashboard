using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class ServiceConfigerationViewModel
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public int TimeOut { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public List<ServiceConfigParmsViewModel> ServiceConfigParms { get; set; }
    }
}
