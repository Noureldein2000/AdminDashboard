﻿using AdminDashboard.Areas.SuperAdmin.Models;
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
        private readonly IAccountTypeProfileApi accountTypeProfileApi;
        private readonly IConfiguration _configuration;
        //private readonly IAccountTypeApi accountTypeProfileApi;
        public AccountTypeProfileController(IConfiguration configuration)
        {
            _configuration = configuration;
            string url = _configuration.GetValue<string>("Urls:Authority");
            //string url = "https://localhost:44303";
            //string urlTms = "https://localhost:44321";
            accountTypeProfileApi = new AccountTypeProfileApi(url);
        }
        public async Task<IActionResult> Index(int page = 1, int size = 10, string language = "ar")
        {
            var model = await accountTypeProfileApi.ApiAccountTypeProfileGetAllGetAsync(page, size);

            var viewModel = new PagedResult<AccountTypeProfileViewModel>
            {
                Results = model.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)model.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstAccountType.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var profiles = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstProfile.Select(a => new SelectListItem
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
                var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstAccountType.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                var profiles = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstProfile.Select(a => new SelectListItem
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
                var result = accountTypeProfileApi.ApiAccountTypeProfileAddPost(new AccountTypeProfileModel
                    (
                    accountTypeID: model.AccountTypeID,
                    profileID: model.ProfileID
                    ));

                TempData["result"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["result"] = false;

                var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstAccountType.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                var profiles = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstProfile.Select(a => new SelectListItem
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
            accountTypeProfileApi.ApiAccountTypeProfileDeleteIdDelete(id);
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