using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class DenominationParameterViewModel
    {
        public int Id { get; set; }
        public int DenominationID { get; set; }
        [Required]
        public int Sequence { get; set; }
        public bool Optional { get; set; }
        [Required]
        public int DenominationParamID { get; set; }
        public string Value { get; set; }
        public string ValueList { get; set; }
        public string ValidationExpression { get; set; }
        public string ValidationMessage { get; set; }
    }
}
