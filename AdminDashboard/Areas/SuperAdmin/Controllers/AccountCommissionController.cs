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
    public class AccountCommissionController : Controller
    {
        private readonly IAccountApi api;
        private readonly ICommissionApi apiCommission;
        private readonly IAccountCommissionApi apiAccountCommission;
        private readonly IDenominationApi apiDenomination;
        private readonly IAdminServiceApi apiService;
        public AccountCommissionController(
            )
        {
            string url = "https://localhost:44303";
            string urlTms = "https://localhost:44321";
            api = new AccountApi(url);
            apiCommission = new CommissionApi(urlTms);
            apiAccountCommission = new AccountCommissionApi(urlTms);
            apiDenomination = new DenominationApi(urlTms);
            apiService = new AdminServiceApi(urlTms);
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? accountId = null, int page = 1)
        {
            var data = await apiAccountCommission.ApiAccountCommissionGetAccountCommissionByAccountIdAccountIdGetAsync(accountId, page, 10);

            var viewModel = new PagedResult<AccountCommissionViewModel>
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
            var commissions = apiCommission.ApiCommissionGetCommissionsGet().Select(a => new SelectListItem
            {
                Text = a.CommissionRange.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var services = apiService.ApiAdminServiceGetServicesGet(1, 1000, "ar").Results.Select(a => new SelectListItem
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
                var commissions = apiCommission.ApiCommissionGetCommissionsGet().Select(a => new SelectListItem
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
                model.Commissions = commissions;

                return View(model);
            }

            apiAccountCommission.ApiAccountCommissionAddAccountCommissionPost(new AddAccountCommissionModel(
                accountId: model.AccountId,
                denominationId: model.DenominationId,
                commissionId: model.CommissionId));

            return RedirectToAction(nameof(Index), new { accountId = model.AccountId });
        }

        [HttpGet]
        public IActionResult DeleteAccountCommission(int id, int accountId)
        {
            apiAccountCommission.ApiAccountCommissionDeleteAccountCommissionIdDelete(id: id);

            return RedirectToAction(nameof(Index), new { accountId = accountId });
        }

        [HttpGet]
        public JsonResult GetDenomoinationsByServiceId(int serviceId)
        {
            var denominations = apiDenomination.ApiDenominationGetDenominationsByServiceIdServiceIdGet(serviceId, 1, 100, "ar").Results;
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
