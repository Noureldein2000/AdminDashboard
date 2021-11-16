using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class AccountFeesController : Controller
    {
        private readonly IAccountApi api;
        private readonly IFeesApi apiFees;
        private readonly IAccountFeesApi apiAccountFees;
        private readonly IDenominationApi apiDenomination;
        private readonly IAdminServiceApi apiService;
        private readonly IConfiguration _configuration;
        public AccountFeesController(IConfiguration configuration)
        {
            _configuration = configuration;
            string url = _configuration.GetValue<string>("Urls:Authority");
            string urlTms = _configuration.GetValue<string>("Urls:TMS");
            api = new AccountApi(url);
            apiFees = new FeesApi(urlTms);
            apiAccountFees = new AccountFeesApi(urlTms);
            apiDenomination = new DenominationApi(urlTms);
            apiService = new AdminServiceApi(urlTms);
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? accountId = null, int page = 1)
        {
            var data = await apiAccountFees.ApiAccountFeesGetAccountFeesByAccountIdAccountIdGetAsync(accountId, page, 10);

            var viewModel = new PagedResult<AccountFeesViewModel>
            {
                Results = data.Results.Select(u => Map(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = 10
            };

            ViewBag.AccountId = accountId;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create(int accountId)
        {
            var fees = apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = a.FeeRange.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var services = apiService.ApiAdminServiceGetServicesGet(1, 1000, "ar").Results.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateAccountFeesViewModel
            {
                AccountId = accountId,
                Fees = fees,
                Services = services
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAccountFeesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var fees = apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
                {
                    Text = a.Value.ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                var services = apiService.ApiAdminServiceGetServicesGet(1, 1000, "ar").Results.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                model.Services = services;
                model.Fees = fees;

                return View(model);
            }

            apiAccountFees.ApiAccountFeesAddAccountFeesPost(new AddAccountFeeModel(
                accountId: model.AccountId,
                denominationId: model.DenominationId,
                feeId: model.FeesId));

            return RedirectToAction(nameof(Index), new { accountId = model.AccountId });
        }

        [HttpGet]
        public JsonResult DeleteAccountFee(int id)
        {
            apiAccountFees.ApiAccountFeesDeleteAccountFeeIdDelete(id: id);

            return Json(id);
        }

        [HttpGet]
        public JsonResult GetDenomoinationsByServiceId(int serviceId)
        {
            var denominations = apiDenomination.ApiDenominationGetDenominationsByServiceIdServiceIdGet(serviceId, 1, 100, "ar").Results;
            return Json(denominations);
        }
        private AccountFeesViewModel Map(AccountFeesModel x)
        {
            return new AccountFeesViewModel
            {

                Id = (int)x.Id,
                FeesId = (int)x.FeesId,
                FeesTypeId = (int)x.FeesTypeId,
                FeesTypeName = x.FeesTypeName,
                PaymentMode = x.PaymentMode,
                FeesValue = x.FeesValue,
                PaymentModeId = (int)x.PaymentModeId,
                DenomiinationId = (int)x.DenomiinationId,
                DenominationFullName = x.DenominationFullName,
            };
        }
    }
}
