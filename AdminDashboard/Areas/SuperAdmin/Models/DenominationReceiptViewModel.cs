using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class DenominationReceiptViewModel
    {
        public int ID { get; set; }
        public DenominationReceiptDataViewModel DenominationReceiptData { get; set; }
        public List<DenominationReceiptParamViewModel> DenominationReceiptParams { get; set; }
    }
}
