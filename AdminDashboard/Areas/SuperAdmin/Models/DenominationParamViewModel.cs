using AdminDashboard.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class DenominationParamViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Label { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ParamKey { get; set; }
        [Required]
        [EnumDataType(typeof(DenominationParamsValueMode), ErrorMessage = "You must choose a Value Mode")]
        public DenominationParamsValueMode ValueModeID { get; set; }
        public string ValueModeName { get; set; }
        [Required]
        [EnumDataType(typeof(DenominationParamsValueType), ErrorMessage = "You must choose a Value Type")]
        public DenominationParamsValueType ValueTypeID { get; set; }
        public string ValueTypeName { get; set; }
    }
}
