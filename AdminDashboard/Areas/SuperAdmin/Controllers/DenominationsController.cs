using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Helper;
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
    public class DenominationsController : Controller
    {
        private readonly IAdminServiceApi api;
        private readonly IDenominationApi apiDenomination;
        private readonly IServiceProviderApi apiServiceProvider;
        private readonly IServiceConfigurationApi apiServiceConfiguration;
        public DenominationsController(
            )
        {
            //string urlIdentity = "https://localhost:44303";
            string urlTms = "https://localhost:44321";
            api = new AdminServiceApi(urlTms);
            apiDenomination = new DenominationApi(urlTms);
            apiServiceProvider = new ServiceProviderApi(urlTms);
            apiServiceConfiguration = new ServiceConfigurationApi(urlTms);
        }

        public async Task<IActionResult> Index(int? id, int page = 1, int size = 10)
        {
            id ??= (int)TempData["serviceId"];

            var data = await apiDenomination.ApiDenominationGetDenominationsByServiceIdServiceIdGetAsync(id, page, size, "ar");

            var viewModel = new PagedResult<DenominationViewModel>
            {
                Results = data.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            TempData["serviceId"] = id ?? data.Results.FirstOrDefault().ServiceID;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create(int serviceId)
        {
            ViewBag.ServicesProvider = apiServiceProvider.ApiServiceProviderGetServiceProviderGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = a.Name.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.ServiceConfiguartion = apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsGet(1,200).Results.Select(a => new SelectListItem
            {
                Text = a.Url.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateDenominationViewModel
            {
                Denomination = new DenominationViewModel() { ServiceID = serviceId },
                DenominationServiceProviders = new DenominationServiceProvidersViewModel(),
                ServiceConfigeration = new ServiceConfigerationViewModel(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateDenominationViewModel model)
        {

            if (!ModelState.IsValid)
            {

                model.Denomination.ServiceID = (int)TempData["serviceId"];

                ViewBag.ServicesProvider = apiServiceProvider.ApiServiceProviderGetServiceProviderGet(1, 100).Results.Select(a => new SelectListItem
                {
                    Text = a.Name.ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                ViewBag.ServiceConfiguartion = apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsGet().Results.Select(a => new SelectListItem
                {
                    Text = a.Url.ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                return View(model);
            }

            apiDenomination.ApiDenominationAddDenominationPost(new AddDenominationModel()
            {
                Denomination = MapToModel(model.Denomination),
                DenominationServiceProviders = MapToModel(model.DenominationServiceProviders),
                //DenominationProviderConfigeration = MapToModel(model.DenominationProviderConfigeration),
                ServiceConfigeration = MapToModel(model.ServiceConfigeration),
                //ServiceConfigParms = MapToModel(model.ServiceConfigParms),
            });

            return RedirectToAction(nameof(Index), new { id = model.Denomination.ServiceID });
        }

        [HttpPost]
        public JsonResult CreateServiceConfiguartion(ServiceConfigerationViewModel model)
        {
            var viewModel = apiServiceConfiguration.ApiServiceConfigurationAddServiceConfiguartionsPost(new ServiceConfigerationModel
                 (
                 id: model.Id,
                 url: model.URL,
                 timeOut: model.TimeOut,
                 userName: model.UserName,
                 userPassword: model.UserPassword,
                 serviceConfigParmsModel: model.ServiceConfigParms?.Select(x => MapToModel(x)).ToList()
                 ));

            return Json(viewModel);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = apiDenomination.ApiDenominationGetDenominationByIdIdGet(id);

            var viewModel = new EditDenominationViewModel()
            {
                Denomination = MapToViewModel(model.Denomination),
                DenominationServiceProvidersViewModels = model.DenominationServiceProviders.Select(x => MapToViewModel(x)).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditDenominationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            apiDenomination.ApiDenominationEditDenominationPut(MapToModel(model.Denomination));

            return RedirectToAction(nameof(Index), new { id = model.Denomination.ServiceID });
        }

        [HttpGet]
        public IActionResult ChangeStatus(int id, int serviceId)
        {
            apiDenomination.ApiDenominationChangeStatusPut(id);
            return RedirectToAction(nameof(Index), new { id = serviceId });
        }
        [HttpGet]
        public IActionResult ChangeStatusDenominationServiceProvider(int id, int denominationId)
        {
            apiDenomination.ApiDenominationChangeDenominationServiceProviderStatusPut(id);
            return RedirectToAction(nameof(Edit), new { id = denominationId });
        }

        [HttpGet]
        public IActionResult EditDenominationServiceProvider(int id)
        {
            ViewBag.ServicesProvider = apiServiceProvider.ApiServiceProviderGetServiceProviderGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = a.Name.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.ServiceConfiguartion = apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsGet(1,200).Results.Select(a => new SelectListItem
            {
                Text = a.Url.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var model = apiDenomination.ApiDenominationGetDenominationServiceProviderByDenominationIdIdGet(id);

            return View(MapToViewModel(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDenominationServiceProvider(DenominationServiceProvidersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = MapToViewModel(apiDenomination.ApiDenominationGetDenominationServiceProviderByDenominationIdIdGet(model.Id));

                ViewBag.ServicesProvider = apiServiceProvider.ApiServiceProviderGetServiceProviderGet(1, 100).Results.Select(a => new SelectListItem
                {
                    Text = a.Name.ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                ViewBag.ServiceConfiguartion = apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsGet(1,200).Results.Select(a => new SelectListItem
                {
                    Text = a.Url.ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                return View(model);
            }

            apiDenomination.ApiDenominationEditDenominationServiceProviderPut(MapToModel(model));

            return RedirectToAction(nameof(Edit), new { id = model.DenominationID });
        }

        private DenominationModel MapToModel(DenominationViewModel model)
        {
            return new DenominationModel
            {
                Id = model.Id,
                Name = model.Name,
                ApiValue = model.APIValue,
                CurrencyID = (int)model.CurrencyID,
                ServiceID = model.ServiceID,
                Status = model.Status,
                ClassType = model.ClassType,
                Interval = model.Interval,
                MaxValue = model.MaxValue,
                MinValue = model.MinValue,
                Inquirable = model.Inquirable,
                Value = model.Value,
                BillPaymentModeID = ((int)model.BillPaymentModeID),
                PaymentModeID = ((int)model.PaymentModeID),
                OldDenominationID = model.OldDenominationID,
                PathClass = null,
                ServiceCategoryID = model.ServiceCategoryID
            };
        }
        private DenominationViewModel MapToViewModel(DenominationModel denomination)
        {
            return new DenominationViewModel
            {
                Id = (int)denomination.Id,
                Name = denomination.Name,
                ServiceID = (int)denomination.ServiceID,
                Status = (bool)denomination.Status,
                //ServiceProviderId = (int)denomination.ServiceProviderId,
                PaymentModeID = (PaymentMode)denomination.PaymentModeID,
                PaymentModeName = denomination.PaymentModeName,
                OldDenominationID = denomination.OldDenominationID,
                ServiceCategoryID = (int)denomination.ServiceCategoryID,
                //ServiceEntity = denomination.ServiceEntity,
                Value = (double)denomination.Value,
                APIValue = (double)denomination.ApiValue,
                BillPaymentModeID = (BillPaymentMode)denomination.BillPaymentModeID,
                BillPaymentModeName = denomination.BillPaymentModeName,
                ClassType = denomination.ClassType,
                CurrencyID = (Currency)denomination.CurrencyID,
                Inquirable = (bool)denomination.Inquirable,
                Interval = (int)denomination.Interval,
                MinValue = (double)denomination.MinValue,
                MaxValue = (double)denomination.MaxValue,
                //PathClass = denomination.PathClass
            };
        }
        private DenominationServiceProvidersModel MapToModel(DenominationServiceProvidersViewModel model)
        {
            return new DenominationServiceProvidersModel
            {
                Id = model.Id,
                Balance = (double)model.Balance,
                ProviderAmount = (double)model.ProviderAmount,
                ProviderCode = model.ProviderCode,
                ProviderHasFees = model.ProviderHasFees,
                OldServiceId = (int)model.OldServiceID,
                ServiceProviderId = model.ServiceProviderID,
                Status = model.Status,
                DenominationId = model.DenominationID,
                //DenominationProviderConfigurationModel = model.DenominationProviderConfigeration.Select(x=> MapToModel(x)).ToList()
            };
        }
        private DenominationServiceProvidersViewModel MapToViewModel(DenominationServiceProvidersModel model)
        {
            return new DenominationServiceProvidersViewModel
            {
                Id = (int)model.Id,
                Balance = (double)model.Balance,
                ProviderAmount = (double)model.ProviderAmount,
                ProviderCode = model.ProviderCode,
                ProviderHasFees = (bool)model.ProviderHasFees,
                OldServiceID = (int)model.OldServiceId,
                ServiceProviderID = (int)model.ServiceProviderId,
                ServiceProviderName = model.ServiceProviderName,
                Status = (bool)model.Status,
                DenominationID = (int)model.DenominationId,
                DenominationProviderConfigeration = model.DenominationProviderConfigurationModel.Select(x => MapToViewModel(x)).ToList()
            };
        }
        private DenominationProviderConfigerationModel MapToModel(DenominationProviderConfigerationViewModel model)
        {
            return new DenominationProviderConfigerationModel
            {
                Id = model.ID,
                Name = model.Name,
                Value = model.Value,
                DenominationProviderID = model.DenominationProviderID
            };
        }
        private DenominationProviderConfigerationViewModel MapToViewModel(DenominationProviderConfigerationModel model)
        {
            return new DenominationProviderConfigerationViewModel
            {
                ID = (int)model.Id,
                Name = model.Name,
                Value = model.Value,
                DenominationProviderID = (int)model.DenominationProviderID
            };
        }
        private ServiceConfigerationModel MapToModel(ServiceConfigerationViewModel model)
        {
            return new ServiceConfigerationModel
            {
                Id = model.Id,
                Url = model.URL,
                TimeOut = model.TimeOut,
                UserName = model.UserName,
                UserPassword = model.UserPassword
            };
        }
        private ServiceConfigerationViewModel MapToViewModel(ServiceConfigerationModel model)
        {
            return new ServiceConfigerationViewModel
            {
                Id = (int)model.Id,
                URL = model.Url,
                TimeOut = (int)model.TimeOut,
                UserName = model.UserName,
                UserPassword = model.UserPassword
            };
        }
        private ServiceConfigParmsModel MapToModel(ServiceConfigParmsViewModel model)
        {
            return new ServiceConfigParmsModel
            {
                Id = model.Id,
                Name = model.Name,
                Value = model.Value
            };
        }
    }
}
