using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Helper;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Route("SuperAdmin/[controller]/{action}/{id?}")]
    [Authorize]
    public class SearchDenomniationController : Controller
    {
        private readonly IAdminServiceApi api;
        private readonly IDenominationApi apiDenomination;
        private readonly IConfiguration _configuration;
        public SearchDenomniationController(IConfiguration configuration)
        {
            _configuration = configuration;
            //string url = _configuration.GetValue<string>("Urls:Authority");
            string urlTms = _configuration.GetValue<string>("Urls:TMS");
            api = new AdminServiceApi(urlTms);
            apiDenomination = new DenominationApi(urlTms);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new PagedResult<DenominationViewModel>();
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult SearchByKeysDenomination(string serviceName, string serviceCode, string denomninationName, string denomniationCode, int page = 1, int size = 10, string language = "ar")
        {
            var data = apiDenomination.ApiDenominationSearchDenominationsGet(serviceName, serviceCode, denomninationName, denomniationCode, page, size, language);

            var viewModel = new PagedResult<DenominationViewModel>
            {
                Results = data.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = size,
                ServiceName = serviceName,
                ServiceCode = serviceCode,
                DenomninationName = denomninationName,
                DenomniationCode = denomniationCode,
            };

            return View("Index", viewModel);
        }

        private DenominationViewModel MapToViewModel(DenominationModel denomination)
        {
            return new DenominationViewModel
            {
                Id = (int)denomination.Id,
                Name = denomination.Name,
                ServiceID = (int)denomination.ServiceID,
                ServiceName = denomination.ServiceName,
                Status = (bool)denomination.Status,
                //ServiceProviderId = (int)denomination.ServiceProviderId,
                PaymentModeID = (PaymentMode)denomination.PaymentModeID,
                PaymentModeName = denomination.PaymentModeName,
                OldDenominationID = denomination.OldDenominationID,
                ServiceCategoryID = (int)denomination.ServiceCategoryID,
                //ServiceEntity = denomination.ServiceEntity,
                Value = (double)denomination.Value,
                APIValue = (double)denomination.ApiValue,
                BillPaymentModeID = (BillPaymentMode)denomination.BillPaymentModeID,
                BillPaymentModeName = denomination.BillPaymentModeName,
                ClassType = denomination.ClassType,
                CurrencyID = (Currency)denomination.CurrencyID,
                Inquirable = (bool)denomination.Inquirable,
                Interval = (int)denomination.Interval,
                MinValue = (double)denomination.MinValue,
                MaxValue = (double)denomination.MaxValue,
                //PathClass = denomination.PathClass
            };
        }


    }
}
