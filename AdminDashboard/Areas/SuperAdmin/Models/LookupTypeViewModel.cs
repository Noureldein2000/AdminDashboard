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
        public List<LookupTypeViewModel> GeneralLookups { get; set; }
        public LookupType IdentifierType { get; set; }
    }

    public class LookupTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
    }
    public class AddLookupTypeViewModel
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public LookupType IdentifierType { get; set; }
    }
    public class EditLookupTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public LookupType IdentifierType { get; set; }
    }
}
