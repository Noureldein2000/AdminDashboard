using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IDenominationApi apiDenomination;
        private readonly IAdminServiceApi apiService;
        public AccountFeesController(
            )
        {
            string url = "https://localhost:44303";
            string urlTms = "https://localhost:44321";
            api = new AccountApi(url);
            apiFees = new FeesApi(urlTms);
            apiDenomination = new DenominationApi(urlTms);
            apiService = new AdminServiceApi(urlTms);
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? accountId = null, int page = 1)
        {
            var data = await apiFees.ApiFeesGetAccountFeesByAccountIdAccountIdGetAsync(accountId, page, 10);

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
            var fees = apiFees.ApiFeesGetFeesGet().Select(a => new SelectListItem
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
                var fees = apiFees.ApiFeesGetFeesGet().Select(a => new SelectListItem
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

            apiFees.ApiFeesAddAccountFeePost(new AddAccountFeeModel(
                accountId: model.AccountId,
                denominationId: model.DenominationId,
                feeId: model.FeesId));

            return RedirectToAction(nameof(Index), new { accountId = model.AccountId });
        }

        [HttpGet]
        public IActionResult DeleteAccountFee(int id, int accountId)
        {
            apiFees.ApiFeesDeleteAccountFeeIdDelete(id: id);

            return RedirectToAction(nameof(Index), new { accountId = accountId });
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
