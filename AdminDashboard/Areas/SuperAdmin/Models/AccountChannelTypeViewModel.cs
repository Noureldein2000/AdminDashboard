using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class AccountChannelTypeViewModel
    {
        public int Id { get; set; }
        public int AccountID { get; set; }
        public int ChannelTypeID { get; set; }
        public string ChannelTypeName { get; set; }
        public bool HasLimitedAccess { get; set; }
        [Required]
        public int ExpirationPeriod { get; set; }

        public List<SelectListItem> ChannelTypes { get; set; }
    }
}
