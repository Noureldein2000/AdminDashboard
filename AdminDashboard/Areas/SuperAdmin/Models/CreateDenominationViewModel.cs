using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateDenominationViewModel
    {
        public DenominationViewModel Denomination { get; set; }
        public DenominationServiceProvidersViewModel DenominationServiceProviders { get; set; }
        public ServiceConfigerationViewModel ServiceConfigeration { get; set; }

    }
}
