using AdminDashboard.Constants;
using AdminDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Services
{
    public interface IIntegrations
    {
        Task<Dictionary<ResponceStatus, string>> InvokeSeedUniversityCashout(int serviceId, UniversityCashoutSeedListModel model);
    }
}
