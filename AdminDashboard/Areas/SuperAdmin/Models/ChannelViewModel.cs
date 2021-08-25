using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class ChannelViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChannelTypeID { get; set; }
        public string ChannelTypeName { get; set; }
        public int ChannelOwnerID { get; set; }
        public string ChannelOwnerName { get; set; }
        public string Serial { get; set; }
        public int PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; }
        public string Value { get; set; }
        public bool Status { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public List<SelectListItem> ChannelTypes { get; set; }
        public List<SelectListItem> ChannelOwners { get; set; }
        public List<SelectListItem> PaymentMethods { get; set; }
    }
}
