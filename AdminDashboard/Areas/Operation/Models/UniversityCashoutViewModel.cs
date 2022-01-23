using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.Operation.Models
{
    public class UniversityCashoutViewModel
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
    }

    public class UniversityCashoutViewModelList
    {
        public List<UniversityCashoutViewModel> DataList { get; set; } = new List<UniversityCashoutViewModel>();
    }
}
