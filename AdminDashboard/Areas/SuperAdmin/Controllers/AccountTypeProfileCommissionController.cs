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

    public class AccountTypeProfileCommissionController : Controller
    {
        private readonly ICommissionApi commissionApi;
        //private readonly IAccountTypeProfileDenominationApi accountTypeProfileDenominationApi;
        private readonly IAccountTypeProfileCommissionApi accountTypeProfileCommissionApi;
        private readonly IConfiguration _configuration;
        public AccountTypeProfileCommissionController(IConfiguration configuration)
        {
            _configuration = configuration;
            string urlTms = _configuration.GetValue<string>("Urls:TMS");
            commissionApi = new CommissionApi(urlTms);
            accountTypeProfileCommissionApi = new AccountTypeProfileCommissionApi(urlTms);
        }
        public async Task<IActionResult> Index(int id, string title, int page = 1, int size = 10)
        {
            var model = await accountTypeProfileCommissionApi.ApiAccountTypeProfileCommissionGetAccountTypeProfileCommissionsIdGetAsync(id, page, size, "ar");

            var viewModel = new PagedResult<AccountTypeProfileCommissionViewModel>
            {
                Results = model.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)model.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            ViewBag.FullTitle = title;
            return View(viewModel);
        }

        public IActionResult Create(int id)
        {
            var Commissions = commissionApi.ApiCommissionGetCommissionsGet(1, 1000, "ar").Results.Select(a => new SelectListItem
            {
                Text = a.CommissionRange,
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateAccountTypeProfileCommissionViewModel
            {
                AccountTypeProfileDenominationID = id,
                Commissions = Commissions
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAccountTypeProfileCommissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var Commissions = commissionApi.ApiCommissionGetCommissionsGet(1, 1000, "ar").Results.Select(a => new SelectListItem
                {
                    Text = a.CommissionRange,
                    Value = a.Id.ToString()
                }).ToList();

                model.Commissions = Commissions;

                return View(model);
            }

            accountTypeProfileCommissionApi.ApiAccountTypeProfileCommissionAddAccountTypeProfileCommissionPost(new AccountTypeProfileCommissionModel
                (
                accountTypeProfileDenominationID: model.AccountTypeProfileDenominationID,
                commissionID: model.CommissionId
                ));

            return RedirectToAction(nameof(Index), new { id = model.AccountTypeProfileDenominationID });
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            accountTypeProfileCommissionApi.ApiAccountTypeProfileCommissionDeleteIdDelete(id);
            return Json(id);
        }

        private AccountTypeProfileCommissionModel MapToModel(AccountTypeProfileCommissionViewModel x)
        {
            return new AccountTypeProfileCommissionModel
            {
                Id = (int)x.Id,
                AmountFrom = (double)x.AmountFrom,
                AmountTo = (double)x.AmountTo,
                CommissionTypeName = x.CommissionTypeName,
                PaymentModeName = x.PaymentModeName,
                CommissionValue = (double)x.CommissionValue,
                AccountTypeProfileDenominationID = x.AccountTypeProfileDenominationID,
                DenomintionName = x.DenomintionName,
                ServiceName = x.ServiceName,
                CommissionID = x.CommissionID,
                AccountTypeName = x.AccountTypeName,
                ProfileName = x.ProfileName
            };
        }

        private AccountTypeProfileCommissionViewModel MapToViewModel(AccountTypeProfileCommissionModel x)
        {
            return new AccountTypeProfileCommissionViewModel
            {
                Id = (int)x.Id,
                AmountFrom = (decimal)x.AmountFrom,
                AmountTo = (decimal)x.AmountTo,
                CommissionTypeName = x.CommissionTypeName,
                PaymentModeName = x.PaymentModeName,
                CommissionValue = (decimal)x.CommissionValue,
                AccountTypeProfileDenominationID = (int)x.AccountTypeProfileDenominationID,
                DenomintionName = x.DenomintionName,
                ServiceName = x.ServiceName,
                CommissionID = (int)x.CommissionID,
                AccountTypeName = x.AccountTypeName,
                ProfileName = x.ProfileName
            };
        }
    }
}
