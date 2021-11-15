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
    public class AccountTypeProfileDenominationController : Controller
    {
        private readonly IAccountTypeProfileApi accountTypeProfileApi;
        private readonly IAccountTypeProfileDenominationApi accountTypeProfileDenominationApi;
        private readonly IDenominationApi denominationApi;
        private readonly IAdminServiceApi adminServiceApi;
        public AccountTypeProfileDenominationController(
            )
        {
            string url = "https://localhost:44303";
            string urlTms = "https://localhost:44321";
            accountTypeProfileApi = new AccountTypeProfileApi(url);
            accountTypeProfileDenominationApi = new AccountTypeProfileDenominationApi(urlTms);
            denominationApi = new DenominationApi(urlTms);
            adminServiceApi = new AdminServiceApi(urlTms);
        }

        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var model = await accountTypeProfileDenominationApi.ApiAccountTypeProfileDenominationGetAccountTypeProfileDenominationsGetAsync(page, size);

            var accountTypesAndProfile = accountTypeProfileApi.ApiAccountTypeProfileGetAllGet(1, 1000).Results.Where(x => model.Results.Select(d => d.AccountTypeProfileID).Contains(x.Id))
                .Select(e => new AccountTypeProfileModel
                {
                    Id = (int)e.Id,
                    AccountType = e.AccountType,
                    Profile = e.Profile
                }).ToList();

            var viewModel = new PagedResult<AccountTypeProfileDenominationViewModel>
            {
                Results = model.Results.Select(u => new AccountTypeProfileDenominationViewModel()
                {
                    Id = (int)u.Id,
                    AccountTypeProfileID = (int)u.AccountTypeProfileID,
                    Status = (bool)u.Status,
                    DenominationID = (int)u.DenominationID,
                    DenominationName = u.DenominationName,
                    AccountTypeName = accountTypesAndProfile.Where(x => x.Id == u.AccountTypeProfileID).Select(x => x.AccountType).FirstOrDefault(),
                    ProfileName = accountTypesAndProfile.Where(x => x.Id == u.AccountTypeProfileID).Select(x => x.Profile).FirstOrDefault()
                }).ToList(),
                PageCount = (int)model.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var services = adminServiceApi.ApiAdminServiceGetServicesGet(1, 1000, "ar").Results.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var accountTypeProfiles = accountTypeProfileApi.ApiAccountTypeProfileGetAllGet(1, 1000).Results.Select(a => new SelectListItem
            {
                Text = a.FullName,
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateAccountTypeProfileDenominationViewModel
            {
                AcountTypeProfiles = accountTypeProfiles,
                Services = services
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAccountTypeProfileDenominationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var services = adminServiceApi.ApiAdminServiceGetServicesGet(1, 1000, "ar").Results.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                var accountTypeProfiles = accountTypeProfileApi.ApiAccountTypeProfileGetAllGet(1, 1000).Results.Select(a => new SelectListItem
                {
                    Text = a.FullName,
                    Value = a.Id.ToString()
                }).ToList();


                model.AcountTypeProfiles = accountTypeProfiles;
                model.Services = services;

                return View(model);
            }

            accountTypeProfileDenominationApi.ApiAccountTypeProfileDenominationAddAccountTypeProfileDenominationsPost(new AccountTypeProfileDenominationModel
                (
                accountTypeProfileID: model.AccountTypeProfileID,
                denominationID: model.DenominationID
                ));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            accountTypeProfileDenominationApi.ApiAccountTypeProfileDenominationChangeAccountTypeProfileDenominationStatusIdPut(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            accountTypeProfileDenominationApi.ApiAccountTypeProfileDenominationDeleteAccountTypeProfileDenominationIdDelete(id);
            return Json(id);
        }
        [HttpGet]
        public JsonResult GetDenomoinationsByServiceId(int serviceId)
        {
            var denominations = denominationApi.ApiDenominationGetDenominationsByServiceIdServiceIdGet(serviceId, 1, 100, "ar").Results;
            return Json(denominations);
        }

        private AccountTypeProfileDenominationViewModel MapToViewModel(AccountTypeProfileDenominationModel model)
        {
            return new AccountTypeProfileDenominationViewModel
            {
                Id = (int)model.Id,
                DenominationName = model.DenominationName,
                DenominationID = (int)model.DenominationID,
                AccountTypeProfileID = (int)model.AccountTypeProfileID,
                AccountTypeName = model.AccountTypeName,
                ProfileName = model.ProfileName,
                Status = (bool)model.Status
            };
        }
        private AccountTypeProfileDenominationModel MapToModel(AccountTypeProfileDenominationViewModel model)
        {
            return new AccountTypeProfileDenominationModel
            {
                Id = (int)model.Id,
                DenominationName = model.DenominationName,
                DenominationID = (int)model.DenominationID,
                AccountTypeProfileID = (int)model.AccountTypeProfileID,
                AccountTypeName = model.AccountTypeName,
                ProfileName = model.ProfileName,
                Status = (bool)model.Status
            };
        }
    }
}
