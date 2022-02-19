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
    public class AccountCommissionController : Controller
    {
        private readonly ICommissionApi _apiCommission;
        private readonly IAccountCommissionApi _apiAccountCommission;
        private readonly IDenominationApi _apiDenomination;
        private readonly IAdminServiceApi _apiService;
        public AccountCommissionController(
            ICommissionApi commissionApi,
            IAccountCommissionApi accountCommissionApi,
            IDenominationApi denominationApi,
            IAdminServiceApi adminServiceApi)
        {
            _apiCommission = commissionApi;
            _apiAccountCommission = accountCommissionApi;
            _apiDenomination = denominationApi;
            _apiService = adminServiceApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? accountId = null, int page = 1, bool processSucceded = false)
        {
            var data = await _apiAccountCommission.ApiAccountCommissionGetAccountCommissionByAccountIdAccountIdGetAsync(accountId, page, 10);

            var viewModel = new PagedResult<AccountCommissionViewModel>
            {
                Results = data.Results.Select(u => Map(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = 10
            };

            ViewBag.AccountId = accountId;
            ViewBag.processSucceded = processSucceded;
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create(int accountId)
        {
            var commissions = _apiCommission.ApiCommissionGetCommissionsGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = $"From: {a.AmountFrom} To: {a.AmountTo}, Value: {a.Value} {a.PaymentModeName}",
                Value = a.Id.ToString()
            }).ToList();

            var services = _apiService.ApiAdminServiceGetServicesGet(1, 1000, "ar").Results.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateAccountCommissionViewModel
            {
                AccountId = accountId,
                Commissions = commissions,
                Services = services
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAccountCommissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var commissions = _apiCommission.ApiCommissionGetCommissionsGet(1, 100).Results.Select(a => new SelectListItem
                {
                    Text = $"From: {a.AmountFrom} To: {a.AmountTo}, Value: {a.Value} {a.PaymentModeName}",
                    Value = a.Id.ToString()
                }).ToList();

                var services = _apiService.ApiAdminServiceGetServicesGet(1, 1000, "ar").Results.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                model.Services = services;
                model.Commissions = commissions;

                return View(model);
            }

            _apiAccountCommission.ApiAccountCommissionAddAccountCommissionPost(new AddAccountCommissionModel(
                accountId: model.AccountId,
                denominationId: model.DenominationId,
                commissionId: model.CommissionId));

            return RedirectToAction(nameof(Index), new { accountId = model.AccountId, processSucceded = true });
        }

        [HttpGet]
        public JsonResult DeleteAccountCommission(int id)
        {
            _apiAccountCommission.ApiAccountCommissionDeleteAccountCommissionIdDelete(id: id);

            return Json(id);
        }

        [HttpGet]
        public JsonResult GetDenomoinationsByServiceId(int serviceId)
        {
            var denominations = _apiDenomination.ApiDenominationGetDenominationsByServiceIdServiceIdGet(serviceId, 1, 100, "ar").Results;
            return Json(denominations);
        }

        private AccountCommissionViewModel Map(AccountCommissionModel x)
        {
            return new AccountCommissionViewModel
            {

                Id = (int)x.Id,
                CommissionId = (int)x.CommissionId,
                CommissionTypeId = (int)x.CommissionTypeId,
                CommissionTypeName = x.CommissionTypeName,
                PaymentMode = x.PaymentMode,
                CommissionValue = x.CommissionValue,
                PaymentModeId = (int)x.PaymentModeId,
                DenomiinationId = (int)x.DenomiinationId,
                DenominationFullName = x.DenominationFullName,
            };
        }
    }
}
