using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
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
        private readonly IAccountsApi accounts;
        private readonly IRegionApi regionApi;
        private readonly IActivityApi activityApi;
        private readonly IEntityApi entityApi;
        private readonly IAccountTypeProfileApi accountTypeProfileApi;
        private readonly IAccountChannelApi accountChannelApi;
        private readonly IChannelApi channelApi;
        private readonly IAccountChannelTypeApi accountChannelTypesApi;
        private readonly IChannelTypeApi channelTypeApi;
        private readonly IUsersApi usersApi;
        private readonly IChannelOwnerApi channelOwnerApi;
        private readonly IChannelPaymentMethodApi channelPaymentMethodApi;
        private readonly IConfiguration _configuration;
        public AccountsController(IConfiguration configuration)
        {
            _configuration = configuration;
            string url = _configuration.GetValue<string>("Urls:Authority");
            string urlSOF = _configuration.GetValue<string>("Urls:SOF");
            api = new AccountApi(url);
            accounts = new AccountsApi(urlSOF);
            regionApi = new RegionApi(url);
            activityApi = new ActivityApi(url);
            entityApi = new EntityApi(url);
            accountTypeProfileApi = new AccountTypeProfileApi(url);
            accountChannelApi = new AccountChannelApi(url);
            channelApi = new ChannelApi(url);
            accountChannelTypesApi = new AccountChannelTypeApi(url);
            channelTypeApi = new ChannelTypeApi(url);
            usersApi = new UsersApi(url);
            channelOwnerApi = new ChannelOwnerApi(url);
            channelPaymentMethodApi = new ChannelPaymentMethodApi(url);
        }
        [HttpGet]
        public IActionResult Index()
        {
            //var data = api.ApiAccountGetAccountsGet(page, 10);
            //var dd = data.Results.Select(account => Map(account)).ToList();
            //var viewModel = new PagedResult<AccountViewModel>
            //{
            //    Results = dd,
            //    PageCount = (int)data.PageCount,
            //    CurrentPage = page,
            //    PageSize = 10
            //};
            var data = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet();

            ViewBag.AccountTypeList = data.LstAccountType.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            return View(new PagedResult<AccountViewModel>());
        }
        [HttpGet]
        public IActionResult SearchAccounts(int? dropDownFilter, string searchKey, int page = 1)
        {
            var data = api.ApiAccountGetAccountsBySearchKeyGet(dropDownFilter, searchKey, page);

            var dd = data.Results.Select(account => Map(account)).ToList();

            var viewModel = new PagedResult<AccountViewModel>
            {
                Results = dd,
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = 10
            };

            var accoutTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet();

            ViewBag.AccountTypeList = accoutTypes.LstAccountType.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            return View("Index", viewModel);
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

            var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstAccountType.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var balanceTypes = accounts.ApiAccountsBalanceTypesGet("ar").Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateAccountViewModel
            {
                Activities = activities,
                Governerates = governerates,
                Entities = entities,
                AccountTypes = accountTypes,
                BalanceTypes = balanceTypes
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
                var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstAccountType.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                ;
                if (model.AccountTypeID.HasValue)
                {
                    var accountTypeProfiles = accountTypeProfileApi.ApiAccountTypeProfileGetProfilesByAccountTypeIdIdGet(model.AccountTypeID).Select(a => new SelectListItem
                    {
                        Text = a.Profile,
                        Value = a.Id.ToString()
                    }).ToList();
                    model.AccountTypeProfiles = accountTypeProfiles;
                }

                var balanceTypes = accounts.ApiAccountsBalanceTypesGet("ar").Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                model.Activities = activities;
                model.Governerates = governerates;
                model.Entities = entities;
                model.AccountTypes = accountTypes;
                model.BalanceTypes = balanceTypes;

                if (model.GovernerateID.HasValue)
                {
                    var cities = regionApi.ApiRegionGetRegionByGovernorateIdIdGet(model.GovernerateID).ToList();
                    model.Regions = cities.Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.Id.ToString()
                    }).ToList();
                }
                //if (model.ParentAccountID.HasValue)
                //{
                //    var accounts = accountTypeProfileApi.ApiAccountTypeProfileGetParentAccountsIdGet(model.AccountTypeProfileID);
                //    model.ParentAccounts = accounts.Select(s => new SelectListItem
                //    {
                //        Text = s.AccountName,
                //        Value = s.Id.ToString()
                //    }).ToList();
                //}
                return View(model);
            }

            var result = api.ApiAccountAddAccountPost(new AddAccountModel(
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
                 entityID: model.EntityID,
                 parentID: model.ParentAccountID
                 ));
            model.UserRole = Roles.AccountAdmin;
            model.ConsumerUser.UserRole = Roles.Consumer;
            if (result != null)
            {
                accounts.ApiAccountsCreateAccountAccountIdBalancesAmountBalanceTypeIdPost(accountId: result.Id, 0.0, model.BalanceTypeId);

                usersApi.ApiUsersCreateUserPost(new CreateUserModel(
                                username: model.Username,
                                mobile: model.Mobile,
                                //password: model.Password,
                                accountId: result.Id,
                                email: model.UserEmail,
                                userRole: model.UserRole
                                ));

                if (model.ConsumerUser.Mobile != null && model.ConsumerUser.UserEmail != null && model.ConsumerUser.Username != null)
                    usersApi.ApiUsersCreateUserPost(new CreateUserModel(
                                   username: model.ConsumerUser.Username,
                                   mobile: model.ConsumerUser.Mobile,
                                   //password: model.Password,
                                   accountId: result.Id,
                                   email: model.ConsumerUser.UserEmail,
                                   userRole: model.ConsumerUser.UserRole
                                   ));
            }


            TempData["result"] = true;
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
            var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstAccountType.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var balanceTypes = accounts.ApiAccountsBalanceTypesGet("ar").Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var model = api.ApiAccountGetAccountByIdIdGet(id);

            var viewModel = Map(model);

            viewModel.Activities = activities;
            viewModel.Governerates = governerates;
            viewModel.Entities = entities;
            viewModel.AccountTypes = accountTypes;
            viewModel.BalanceTypes = balanceTypes;
            if (model.GovernerateID.HasValue)
            {
                var cities = regionApi.ApiRegionGetRegionByGovernorateIdIdGet(model.GovernerateID).ToList();
                viewModel.Regions = cities.Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                }).ToList();
            }
            //if (model.ParentID.HasValue)
            //{
            //    var accounts = accountTypeProfileApi.ApiAccountTypeProfileGetParentAccountsIdGet(model.AccountTypeProfileID);
            //    viewModel.ParentAccounts = accounts.Select(s => new SelectListItem
            //    {
            //        Text = s.AccountName,
            //        Value = s.Id.ToString()
            //    }).ToList();
            //}

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
                var accountTypes = accountTypeProfileApi.ApiAccountTypeProfileGetAccountTypesAndProfilesGet().LstAccountType.Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var balanceTypes = accounts.ApiAccountsBalanceTypesGet("ar").Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                model.Activities = activities;
                model.Governerates = governerates;
                model.Entities = entities;
                model.AccountTypes = accountTypes;
                model.BalanceTypes = balanceTypes;
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
                    entityID: model.EntityID,
                    parentID: model.ParentAccountID
                    ));

                TempData["result"] = true;
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
                Value = d.Value,
                Status = d.Status,
                CreatedBy = (int)d.CreatedBy,
                CreatedName = d.CreatedName
            });


            //var statusCreated = new List<AccountChannelStatus>() { AccountChannelStatus.Created};

            //var status = Enum.GetValues(typeof(AccountChannelStatus)).Cast<AccountChannelStatus>().Except(statusCreated);


            //ViewBag.Status = status.Select(a => new SelectListItem
            //{
            //    Text = a.ToString(),
            //    Value = ((int)a).ToString()
            //}).ToList();
            var channelTypes = channelTypeApi.ApiChannelTypeGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var channelOwners = channelOwnerApi.ApiChannelOwnerGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var channelPaymentMethods = channelPaymentMethodApi.ApiChannelPaymentMethodGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            return View(new AccountChannelModelViewModel
            {
                AccountChannels = viewModel.ToList(),
                CreateChannelAccount = new CreateChannelAccountViewModel
                {
                    AccountId = id,
                    ChannelOwners = channelOwners,
                    ChannelTypes = channelTypes,
                    PaymentMethods = channelPaymentMethods
                }
            });
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
        //[HttpGet]
        //public IActionResult DeleteAccountChannel(int id)
        //{
        //    var result = accountChannelApi.ApiAccountChannelDeleteIdDelete(id);
        //    return RedirectToAction(actionName: "ViewChannels", new { id = result.AccountID });
        //}
        [HttpGet]
        public IActionResult DeleteAccountChannelType(int id)
        {
            var result = accountChannelTypesApi.ApiAccountChannelTypeDeleteAccountChannelTypesIdDelete(id);
            return RedirectToAction(actionName: "ViewChannelsTypes", new { id = result.AccountID });
        }
        [HttpGet]
        public IActionResult ChangeAccountChannel(int id, AccountChannelStatus status, string reason)
        {
            accountChannelApi.ApiAccountChannelChangeStatusIdPut(id, status, reason);
            return Ok();
        }
        [HttpGet]
        public IActionResult CreateAccountChannel(int accountId, int channelId)
        {
            accountChannelApi.ApiAccountChannelAddPost(new AccountChannelModel(accountID: accountId, channelID: channelId, reason: "Transfered"));
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
        public JsonResult GetAccountTypesByParentId(int id, int accountId)
        {
            var account = accountTypeProfileApi.ApiAccountTypeProfileGetParentAccountsIdAccountIdGet(id, accountId);
            return Json(account);
        }
        [HttpGet]
        public JsonResult GetChannels(string serial, int page = 1)
        {
            var data = channelApi.ApiChannelSearchSpecificChannelBySerialSearchKeyGet(serial, page, 1000);
            return Json(data.Results.Select(chnel => Map(chnel)).ToList());
        }
        [HttpGet]
        public JsonResult GetAccountById(int accountId)
        {
            var data = api.ApiAccountGetAccountByIdIdGet(accountId);
            return Json(data);
        }
        [HttpGet]
        public JsonResult GetAccountProfilelByAcocuntTypeId(int id)
        {
            var data = accountTypeProfileApi.ApiAccountTypeProfileGetProfilesByAccountTypeIdIdGet(id);
            return Json(data);
        }
        [HttpGet]
        public JsonResult GetAccountMappingValidation(int id)
        {
            var account = accountTypeProfileApi.ApiAccountTypeProfileGetAccountMappingValidationIdGet(id);
            return Json(account);
        }
        [HttpGet]
        public IActionResult AccountChannelsHistory()
        {
            return View(new PagedResult<AccountChannelsHistoryViewModel>());
        }
        [HttpPost]
        public IActionResult AccountChannelsHistory(string searchKey, int page = 1)
        {
            var accounts = accountChannelApi.ApiAccountChannelGetAccountChannelsHistorySearchKeyGet(searchKey);

            return View(new PagedResult<AccountChannelsHistoryViewModel>
            {
                Results = accounts.Select(s => Map(s)).ToList(),
                PageCount = 0,
                CurrentPage = page,
                PageSize = 10
            });
        }
        private AccountChannelsHistoryViewModel Map(AccountChannelHistoryModel model)
        {
            return new AccountChannelsHistoryViewModel
            {
                AccountName = model.AccountName,
                Reason = model.Reason,
                CreatedBy = model.CreatedBy,
                ChannelValue = model.ChannelValue,
                ChannelName = model.ChannelName,
                Status = model.Status
            };
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
                AccountChannelId = (int)model.AccountChannelID,
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
