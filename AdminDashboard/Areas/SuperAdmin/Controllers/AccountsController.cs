using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Route("SuperAdmin/[controller]/{action}/{id?}")]
    [Authorize]
    public class AccountsController : Controller
    {
        //private readonly ISwaggerClient _swagerClient;
        private readonly IAccountApi api;
        private readonly IRegionApi regionApi;
        private readonly IActivityApi activityApi;
        private readonly IEntityApi entityApi;
        private readonly IAccountTypeProfileApi accountTypeProfileApi;
        public AccountsController(
            //ISwaggerClient swagerClient
            )
        {
            //_swagerClient = swagerClient;
            string url = "https://localhost:44303";
            api = new AccountApi(url);
            regionApi = new RegionApi(url);
            activityApi = new ActivityApi(url);
            entityApi = new EntityApi(url);
            accountTypeProfileApi = new AccountTypeProfileApi(url);
        }
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var data = api.ApiAccountGetAccountsGet(page, 10);
            var dd = data.Results.Select(account => Map(account)).ToList();
            var viewModel = new PagedResult<AccountViewModel>
            {
                Results = dd,
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = 10
            };
           
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var activities = activityApi.ApiActivityGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var governerates = regionApi.ApiRegionGetGovernorateGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var entities = entityApi.ApiEntityGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAllGet(1,10000).Select(a => new SelectListItem
            {
                Text = a.FullName,
                Value = a.Id.ToString()
            }).ToList();
            var model = new CreateAccountViewModel
            {
                Activities = activities,
                Governerates = governerates,
                Entities = entities,
                AccountTypeProfiles = accountTypes
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var activities = activityApi.ApiActivityGetAllGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var governerates = regionApi.ApiRegionGetGovernorateGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var entities = entityApi.ApiEntityGetAllGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAllGet(1, 10000).Select(a => new SelectListItem
                {
                    Text = a.FullName,
                    Value = a.Id.ToString()
                }).ToList();
                model.Activities = activities;
                model.Governerates = governerates;
                model.Entities = entities;
                model.AccountTypeProfiles = accountTypes;
                return View(model);
            }

            api.ApiAccountAddAccountPost(new AddAccountModel(
                ownerName: model.OwnerName,
                accountName: model.AccountName,
                mobile: model.Mobile,
                address: model.Address,
                latitude: model.Latitude.ToString(),
                longitude: model.Longitude.ToString(),
                email: model.Email,
                nationalID: model.NationalID,
                commercialRegistrationNo: model.CommercialRegistrationNo,
                taxNo: model.TaxNo,
                activityID: model.ActivityID,
                accountTypeProfileID: model.AccountTypeProfileID,
                regionID: model.RegionID,
                entityID: model.EntityID
                ));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var activities = activityApi.ApiActivityGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var governerates = regionApi.ApiRegionGetGovernorateGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var entities = entityApi.ApiEntityGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAllGet(1, 10000).Select(a => new SelectListItem
            {
                Text = a.FullName,
                Value = a.Id.ToString()
            }).ToList();
            var model = api.ApiAccountGetAccountByIdIdGet(id);
            var viewModel = Map(model);
            viewModel.Activities = activities;
            viewModel.Governerates = governerates;
            viewModel.Entities = entities;
            viewModel.AccountTypeProfiles = accountTypes;
            if (model.GovernerateID.HasValue)
            {
                var cities = regionApi.ApiRegionGetRegionByGovernorateIdIdGet(model.GovernerateID).ToList();
                viewModel.Regions = cities.Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToList();
            }
          
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AccountViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var activities = activityApi.ApiActivityGetAllGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var governerates = regionApi.ApiRegionGetGovernorateGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var entities = entityApi.ApiEntityGetAllGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAllGet(1, 10000).Select(a => new SelectListItem
                {
                    Text = a.FullName,
                    Value = a.Id.ToString()
                }).ToList();
                model.Activities = activities;
                model.Governerates = governerates;
                model.Entities = entities;
                model.AccountTypeProfiles = accountTypes;
                return View(model);
            }
                

            api.ApiAccountEditAccountPut(new EditAccountModel(
                id: model.Id,
                ownerName: model.OwnerName,
                accountName: model.AccountName,
                mobile: model.Mobile,
                address: model.Address,
                latitude: model.Latitude.ToString(),
                longitude: model.Longitude.ToString(),
                email: model.Email,
                nationalID: model.NationalID,
                commercialRegistrationNo: model.CommercialRegistrationNo,
                taxNo: model.TaxNo,
                activityID: model.ActivityID,
                accountTypeProfileID: model.AccountTypeProfileID,
                regionID: model.RegionID,
                entityID: model.EntityID
                ));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            api.ApiAccountChangeAccountStatusIdGet(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public JsonResult GetCities(int id)
        {
            var cities = regionApi.ApiRegionGetRegionByGovernorateIdIdGet(id).ToList();
            return Json(cities);
        }
        [HttpGet]
        public JsonResult GetAccountTypesByParentId(int id)
        {
            var accounts = accountTypeProfileApi.ApiAccountTypeProfileGetParentAccountsIdGet(id);
            return Json(accounts);
        }
        private AccountViewModel Map(AccountModel model)
        {
            return new AccountViewModel
            {
                AccountName = model.AccountName,
                ActivityName = model.ActivityName,
                Address = model.Address,
                CommercialRegistrationNo = model.CommercialRegistrationNo,
                Email = model.Email,
                Id = (int)model.Id,
                Mobile = model.Mobile,
                NationalID = model.NationalID,
                OwnerName = model.OwnerName,
                TaxNo = model.TaxNo,
                ActivityID = model.ActivityID,
                RegionID = model.RegionID,
                AccountTypeProfileID = model.AccountTypeProfileID,
                EntityID = model.EntityID,
                GovernerateID = model.GovernerateID,
                ParentAccountID = model.ParentID,
                Status = (bool)model.Status
            };
        }
    }
}
