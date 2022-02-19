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
    public class AccountTypeProfileController : Controller
    {
        private readonly IAccountTypeProfileApi _accountTypeProfileApi;
        public AccountTypeProfileController(IAccountTypeProfileApi accountTypeProfileApi)
        {
            _accountTypeProfileApi = accountTypeProfileApi;
        }
        public async Task<IActionResult> Index(int page = 1, int size = 10, string language = "ar", bool processSucceded = false)
        {
            var model = await _accountTypeProfileApi.ApiAccountTypeProfileGetAllGetAsync(page, size);

            var viewModel = new PagedResult<AccountTypeProfileViewModel>
            {
                Results = model.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)model.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            ViewBag.processSucceded = processSucceded;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var accountTypes = _accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstAccountType.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var profiles = _accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstProfile.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateAccountTypeProfileViewModel
            {
                AccountTypes = accountTypes,
                Profiles = profiles
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAccountTypeProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var accountTypes = _accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstAccountType.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                var profiles = _accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstProfile.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                model.AccountTypes = accountTypes;
                model.Profiles = profiles;

                return View(model);
            }

            try
            {
                var result = _accountTypeProfileApi.ApiAccountTypeProfileAddPost(new AccountTypeProfileModel
                    (
                    accountTypeID: model.AccountTypeID,
                    profileID: model.ProfileID
                    ));

                return RedirectToAction(nameof(Index), new { processSucceded = true });
            }
            catch (Exception ex)
            {
                TempData["result"] = false;

                var accountTypes = _accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstAccountType.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                var profiles = _accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstProfile.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                model.AccountTypes = accountTypes;
                model.Profiles = profiles;

                return View(model);
            }



        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            _accountTypeProfileApi.ApiAccountTypeProfileDeleteIdDelete(id);
            return Json(id);
        }

        private AccountTypeProfileViewModel MapToViewModel(AccountTypeProfileModel model)
        {
            return new AccountTypeProfileViewModel
            {
                Id = (int)model.Id,
                AccountTypeID = (int)model.AccountTypeID,
                AccountTypeName = model.AccountType,
                FullName = model.FullName,
                ProfileID = (int)model.ProfileID,
                ProfileName = model.Profile
            };
        }
    }
}
