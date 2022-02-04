using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Models
{
    public class EditDenominationViewModel
    {
        [Required]
        public DenominationViewModel Denomination { get; set; }
        public List<DenominationServiceProvidersViewModel> DenominationServiceProvidersViewModels { get; set; }
        public List<DenominationParameterViewModel> DenominationParameters { get; set; }
        public DenominationReceiptViewModel DenominationReceipt{ get; set; }
    }
}
