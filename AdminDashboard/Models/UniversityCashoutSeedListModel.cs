using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminDashboard.Models
{
    public class UniversityCashoutSeedListModel
    {
        public string Language { get; set; } = "ar";
        public List<UniversityCashoutSeedModel> Accounts { get; set; }
    }
    public class UniversityCashoutSeedModel
    {
        [Required]
        [Range(1, 1000000000000)]
        public int AccountId { get; set; }
        [Required]
        [Range(typeof(decimal), "1", "79228162514264337593543950335")]
        public decimal Amount { get; set; }
    }
}
