using AdminDashboard.Models.SwaggerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class AccountChannelViewModel
    {
        public int? Id { get; set; }
        public int? AccountID { get; set; }
        public int? ChannelID { get; set; }
        public string ChannelName { get; set; }
        public string Serial { get; set; }
        public string Value { get; set; }
        public string Reason { get; set; }
        public AccountChannelStatus Status { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedName { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
