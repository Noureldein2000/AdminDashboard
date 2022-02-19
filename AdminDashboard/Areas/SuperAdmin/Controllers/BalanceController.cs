using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.Models.SwaggerModels.SourceOFundSwaggerModels;
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
    public class BalanceController : Controller
    {
        private readonly IAccountsApi _accounts;
        public BalanceController(IAccountsApi accounts)
        {
            _accounts = accounts;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int accountId, string accountName)
        {
            var data = await _accounts.ApiAccountsBalancesAccountIdGetAsync(accountId, "ar");

            var balanceTypeIds = data.Select(x => new BalanceTypeModel
            {
                Id = x.BalanceTypeId,
                Name = x.BalanceType
            }).ToList();

            var balanceTypes = await _accounts.ApiAccountsBalanceTypesGetAsync("ar");

            ViewBag.AccountId = accountId;
            ViewBag.AccountName = accountName;
            ViewBag.AvaliableBalanceType = balanceTypes.Except(balanceTypeIds).Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            return View(data.Select(x => Map(x)));
        }

        [HttpPost]
        public IActionResult Create(AccountBalancesViewModel model)
        {
            _accounts.ApiAccountsCreateAccountPost(new CreateAccountModel(
               accountId: model.AccountId,
               amount: 0.0,
               balanceTypeIds: new List<int?> { model.BalanceTypeId }));

            return RedirectToAction(nameof(Index), new { accountId = model.AccountId, accountName = model.AccountName });
        }

        private AccountBalancesViewModel Map(AccountBalancesModel x)
        {
            return new AccountBalancesViewModel
            {
                TotalBalance = (decimal)x.TotalBalance,
                TotalAvailableBalance = (decimal)x.TotalAvailableBalance,
                BalanceType = x.BalanceType,
                BalanceTypeId = (int)x.BalanceTypeId
            };
        }
    }
}
