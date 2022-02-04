using AdminDashboard.Constants;
using AdminDashboard.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Services
{
    public class Integrations : IIntegrations
    {
        private readonly IConfiguration _configuration;

        public Integrations(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Dictionary<ResponceStatus, string>> InvokeSeedUniversityCashout(int serviceId, UniversityCashoutSeedListModel model)
        {
            var oldServiceAuthenticateUrl = _configuration.GetValue<string>("Urls:OldService");
            var client = new RestClient(oldServiceAuthenticateUrl);
            client.AddDefaultHeader("Accept", "application/json");
            client.AddDefaultHeader("Content-Type", "application/json");
            client.Timeout = 30000;
            var signInRequest = new RestRequest($"/api/accounts/authenticate");

            signInRequest.AddJsonBody(new OldServiceAuthenticateModel
            {
                UserName = "111",
                Password = "25802580",
                AccountID = 6,
                ChannelCategory = 4,
                ChannelType = 9,
                ChannelID = "352966108812146",
                LocalDate = DateTime.Now,
                Version = "",
                ServiceVersion = "",
                Longitude = "62625652",
                Latitude = "444"
            });

            var response = client.Post(signInRequest);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new Dictionary<ResponceStatus, string> { { ResponceStatus.Error, response.ErrorMessage } };
            }
            var authResult = JsonConvert.DeserializeObject<OldServiceResponseModel>(response.Content);
            if(authResult.Code != "200")
            {
                return new Dictionary<ResponceStatus, string> { { ResponceStatus.Error, authResult.Message } };
            }

            var seedRequest = new RestRequest($"/api/services/{serviceId}/balances/seed");
            client.AddDefaultHeader("Authorization", $"Bearer {authResult.Token}");
            seedRequest.AddJsonBody(new UniversityCashoutSeedListModel
            {
                Accounts = model.Accounts
            });
            var seedResponse = client.Post(seedRequest);
            if (seedResponse.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new Dictionary<ResponceStatus, string> { { ResponceStatus.Error, seedResponse.ErrorMessage } };
            }
            var seedResult = JsonConvert.DeserializeObject<OldServiceResponseModel>(seedResponse.Content);
            if (seedResult.Code != "200")
            {
                return new Dictionary<ResponceStatus, string> { { ResponceStatus.Error, seedResult.Message } };
            }

            return new Dictionary<ResponceStatus, string> { { ResponceStatus.Success, seedResult.Message } };

        }
    }
}
