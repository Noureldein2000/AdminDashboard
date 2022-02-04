using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateChannelViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int? ChannelTypeID { get; set; }
        [Required]
        public int? ChannelOwnerID { get; set; }
        [Required]
        public string Serial { get; set; }
        [Required]
        public int? PaymentMethodID { get; set; }
        public string Value { get; set; }
        public bool Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? AccountId { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreationDate { get; set; }

        public List<SelectListItem> ChannelTypes { get; set; }
        public List<SelectListItem> ChannelOwners { get; set; }
        public List<SelectListItem> PaymentMethods { get; set; }
    }
}
