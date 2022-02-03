using AdminDashboard.Helper;
using AdminDashboard.Models.SwaggerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class LookupTypeViewModel
    {
        public List<GeneralLookupTypeViewModel> Fees { get; set; }
        public List<GeneralLookupTypeViewModel> Commissions { get; set; }
        public List<GeneralLookupTypeViewModel> Taxes { get; set; }
    }

    public class GeneralLookupTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public int IdentitfierType { get; set; }
    }

    public class Fee : GeneralLookupTypeViewModel
    {
        public int MaxValue { get; set; }
    }
}
