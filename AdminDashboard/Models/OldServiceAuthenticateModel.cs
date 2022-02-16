using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Models
{
    public class OldServiceAuthenticateModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AccountID { get; set; }
        public int ChannelCategory { get; set; }
        public int ChannelType { get; set; }
        public string ChannelID { get; set; }
        public DateTime LocalDate { get; set; }
        public string Version { get; set; }
        public string ServiceVersion { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Language { get; set; } = "ar";
    }
}
