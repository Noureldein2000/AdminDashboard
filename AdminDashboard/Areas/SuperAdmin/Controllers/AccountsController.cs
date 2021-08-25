﻿using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using AdminDashboard.SwaggerClienti;
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
        private readonly IAccountChannelApi accountChannelApi;
        private readonly IChannelApi channelApi;
        private readonly IAccountChannelTypeApi accountChannelTypesApi;
        private readonly IChannelTypeApi channelTypeApi;
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
            accountChannelApi = new AccountChannelApi(url);
            channelApi = new ChannelApi(url);
            accountChannelTypesApi = new AccountChannelTypeApi(url);
            channelTypeApi = new ChannelTypeApi(url);
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
            var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAllGet(1, 10000).Select(a => new SelectListItem
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

            try
            {

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
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult EditAccountChannelType(int id)
        {
            var data = accountChannelTypesApi.ApiAccountChannelTypeGetAccountChannelTypeByIdIdGet(id);

            var channelTypes = channelTypeApi.ApiChannelTypeGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var viewModel = new AccountChannelTypeViewModel()
            {
                Id = (int)data.Id,
                AccountID = (int)data.AccountID,
                ChannelTypeID = (int)data.ChannelTypeID,
                ChannelTypeName = data.ChannelTypeName,
                ExpirationPeriod = (int)data.ExpirationPeriod,
                HasLimitedAccess = (bool)data.HasLimitedAccess,
                ChannelTypes = channelTypes
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult EditAccountChannelType(AccountChannelTypeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var result = accountChannelTypesApi.ApiAccountChannelTypeEditAccountChannelTypesPut(new EditAccountChannelTypeModel(
                    id: model.Id,
                    hasLimitedAccess: model.HasLimitedAccess,
                    expirationPeriod: model.ExpirationPeriod
                    ));


                return RedirectToAction(actionName: "ViewChannelsTypes", new { id = model.AccountID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
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
        public IActionResult ViewChannels(int id)
        {
            var data = accountChannelApi.ApiAccountChannelGetChannelsByAccountIdAccountIdGet(id);
            var viewModel = data.Select(d => new AccountChannelViewModel()
            {
                Id = d.Id,
                AccountID = d.AccountID,
                ChannelID = d.ChannelID,
                ChannelName = d.ChannelName,
                Serial = d.Serial,
                Status = (bool)d.Status,
                CreatedBy = (int)d.CreatedBy,
                CreatedName = d.CreatedName
            });

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult ViewChannelsTypes(int id)
        {
            var data = accountChannelTypesApi.ApiAccountChannelTypeGetAccountChannelTypesAccountIdGet(id);
            var viewModel = data.Select(d => new AccountChannelTypeViewModel()
            {
                Id = (int)d.Id,
                AccountID = (int)d.AccountID,
                ChannelTypeID = (int)d.ChannelTypeID,
                ChannelTypeName = d.ChannelTypeName,
                ExpirationPeriod = (int)d.ExpirationPeriod,
                HasLimitedAccess = (bool)d.HasLimitedAccess
            });

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult DeleteAccountChannel(int id)
        {
            var result = accountChannelApi.ApiAccountChannelDeleteIdDelete(id);
            return RedirectToAction(actionName: "ViewChannels", new { id = result.AccountID });
        }
        [HttpGet]
        public IActionResult DeleteAccountChannelType(int id)
        {
            var result = accountChannelTypesApi.ApiAccountChannelTypeDeleteAccountChannelTypesIdDelete(id);
            return RedirectToAction(actionName: "ViewChannelsTypes", new { id = result.AccountID });
        }
        [HttpGet]
        public IActionResult ChangeAccountChannel(int id)
        {
            var result = accountChannelApi.ApiAccountChannelChangeStatusIdPut(id);
            return RedirectToAction(actionName: "ViewChannels", new { id = result.AccountID });
        }
        [HttpGet]
        public IActionResult CreateAccountChannel(int accountId, int channelId)
        {
            accountChannelApi.ApiAccountChannelAddPost(new AccountChannelModel(accountID: accountId, channelID: channelId));
            return RedirectToAction(actionName: "ViewChannels", new { id = accountId });
        }
        [HttpGet]
        public IActionResult CreateAccountChannelType(int id)
        {
            var channelTypes = channelTypeApi.ApiChannelTypeGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();


            return View(new CreateAccountChannelTypeViewModel()
            {
                AccountID = id,
                ChannelTypes = channelTypes
            });
        }
        [HttpPost]
        public IActionResult CreateAccountChannelType(CreateAccountChannelTypeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var result = accountChannelTypesApi.ApiAccountChannelTypeAddAccountChannelTypesPost(new AddAccountChannelTypeModel(
               accountID: model.AccountID,
               channelTypeID: model.ChannelTypeID,
               hasLimitedAccess: model.HasLimitedAccess,
               expirationPeriod: model.ExpirationPeriod
               ));

                return RedirectToAction(actionName: "ViewChannelsTypes", new { id = result.AccountID });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }

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
        [HttpGet]
        public JsonResult GetChannels(string serial, int page = 1)
        {
            var data = channelApi.ApiChannelSearchChannelBySerialSearchKeyGet(serial, page, 1000);
            return Json(data.Results.Select(account => Map(account)).ToList());
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

        private ChannelViewModel Map(ChannelResponseModel model)
        {
            return new ChannelViewModel
            {
                Id = (int)model.ChannelID,
                Name = model.Name,
                ChannelTypeID = (int)model.ChannelTypeID,
                ChannelTypeName = model.ChannelTypeName,
                ChannelOwnerID = (int)model.ChannelOwnerID,
                ChannelOwnerName = model.ChannelOwnerName,
                Serial = model.Serial,
                PaymentMethodID = (int)model.PaymentMethodID,
                PaymentMethodName = model.PaymentMethodName,
                Value = model.Value,
                Status = (bool)model.Status,
                CreatedBy = model.CreatedBy,
                UpdatedBy = model.UpdatedBy,
                CreationDate = model.CreationDate
            };
        }
    }
}
