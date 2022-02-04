using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class CreateChannelAccountViewModel
    {
        public int AccountId { get; set; }
        public List<SelectListItem> ChannelTypes { get; set; }
        public List<SelectListItem> ChannelOwners { get; set; }
        public List<SelectListItem> PaymentMethods { get; set; }
    }
}
