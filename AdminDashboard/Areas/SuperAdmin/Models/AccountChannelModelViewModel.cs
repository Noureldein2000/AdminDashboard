using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class AccountChannelModelViewModel
    {
        public List<AccountChannelViewModel> AccountChannels { get; set; }
        public CreateChannelAccountViewModel CreateChannelAccount { get; set; }
    }
}
