using AdminDashboard.Models.SwaggerModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class AdminServiceViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ArName { get; set; }
        public bool Status { get; set; }
        [Required]
        public int? ServiceTypeID { get; set; }
        public string ServiceTypeName { get; set; }
        public string Code { get; set; }
        [Required]
        public int? ServiceEntityID { get; set; }
        public string ServiceEntityName { get; set; }
        public string ServiceCategoryName { get; set; }
        public string PathClass { get; set; }
        [Required]
        [EnumDataType(typeof(ServiceClassType), ErrorMessage = "You Should choose a Class Type")]
        public ServiceClassType ClassType { get; set; }
        public DateTime? CreationDate { get; set; }
        public List<SelectListItem> ServiceEntities { get; set; }
        public List<SelectListItem> ServicesCategories { get; set; }
        public List<SelectListItem> ServiceTypes { get; set; }
    }
}
