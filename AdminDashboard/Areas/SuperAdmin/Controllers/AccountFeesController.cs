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
        //private readonly IAccountApi _api;
        private readonly IFeesApi _apiFees;
        private readonly IAccountFeesApi _apiAccountFees;
        private readonly IDenominationApi _apiDenomination;
        private readonly IAdminServiceApi _apiService;
        public AccountFeesController(
            //IAccountApi api, 
            IFeesApi feesApi,
            IAccountFeesApi accountFeesApi,
            IDenominationApi denominationApi,
            IAdminServiceApi adminServiceApi)
        {
            //_api = api;
            _apiFees = feesApi;
            _apiAccountFees = accountFeesApi;
            _apiDenomination = denominationApi;
            _apiService = adminServiceApi;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? accountId = null, string accountName = null, int page = 1, bool processSucceded = false)
        {
            var data = await _apiAccountFees.ApiAccountFeesGetAccountFeesByAccountIdAccountIdGetAsync(accountId, page, 10);

            var viewModel = new PagedResult<AccountFeesViewModel>
            {
                Results = data.Results.Select(u => Map(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = 10
            };

            ViewBag.AccountId = accountId;
            ViewBag.AccountName = accountName;
            ViewBag.processSucceded = processSucceded;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create(int accountId)
        {
            var fees = _apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = $"From: {a.AmountFrom} To: {a.AmountTo}, Value: {a.Value} {a.PaymentModeName}",
                Value = a.Id.ToString()
            }).ToList();

            var services = _apiService.ApiAdminServiceGetServicesGet(1, 1000, "ar").Results.Select(a => new SelectListItem
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
            try
            {

                if (!ModelState.IsValid)
                {
                    var fees = _apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
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
                    model.Fees = fees;

                    return View(model);
                }
                _apiAccountFees.ApiAccountFeesAddAccountFeesPost(new AddAccountFeeModel(
                    accountId: model.AccountId,
                    denominationId: model.DenominationId,
                    feeId: model.FeesId));

                return RedirectToAction(nameof(Index), new { accountId = model.AccountId, processSucceded = true });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                var fees = _apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
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
                model.Fees = fees;

                return View(model);
            }

        }

        [HttpGet]
        public JsonResult DeleteAccountFee(int id)
        {
            _apiAccountFees.ApiAccountFeesDeleteAccountFeeIdDelete(id: id);

            return Json(id);
        }

        [HttpGet]
        public JsonResult GetDenomoinationsByServiceId(int serviceId)
        {
            var denominations = _apiDenomination.ApiDenominationGetDenominationsByServiceIdServiceIdGet(serviceId, 1, 100, "ar").Results;
            return Json(denominations);
        }
        private AccountFeesViewModel Map(AccountFeesModel x)
        {
            return new AccountFeesViewModel
            {

                Id = (int)x.Id,
                FeesId = (int)x.FeesId,
                FeesTypeId = (int)x.FeesTypeId,
                From = x.AmountFrom,
                To = x.AmountTo,
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
