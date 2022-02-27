using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class DenominationProviderConfigurationViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int DenominationProviderID { get; set; }
    }
}
