using AdminDashboard.Helper;
using AdminDashboard.Models.SwaggerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class LookupTypesViewModel
    {
        public GeneralLookupTypeViewModel Fees { get; set; }
        public GeneralLookupTypeViewModel Commissions { get; set; }
        public GeneralLookupTypeViewModel Taxes { get; set; }
    }

    public class GeneralLookupTypeViewModel
    {
        public GeneralLookupTypeViewModel()
        {
            Types = new List<LookupTypeViewModel>();
        }
        public List<LookupTypeViewModel> Types { get; set; }
        public LookupType IdentitfierType { get; set; }
    }

    public class LookupTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public LookupType IdentitfierType { get; set; }
    }
}
