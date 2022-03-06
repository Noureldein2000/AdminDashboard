using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Helper;
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
    public class DenominationsController : Controller
    {
        private readonly IAdminServiceApi _api;
        private readonly IDenominationApi _apiDenomination;
        private readonly IServiceProviderApi _apiServiceProvider;
        private readonly IServiceConfigurationApi _apiServiceConfiguration;
        private readonly IDenominationParamApi _apiDenominationParams;
        private readonly IParameterApi _apiParameter;
        public DenominationsController(IAdminServiceApi adminServiceApi, IDenominationApi denominationApi,
            IServiceProviderApi serviceProviderApi, IServiceConfigurationApi serviceConfigurationApi,
            IDenominationParamApi denominationParamApi, IParameterApi parameterApi)
        {
            _api = adminServiceApi;
            _apiDenomination = denominationApi;
            _apiServiceProvider = serviceProviderApi;
            _apiServiceConfiguration = serviceConfigurationApi;
            _apiDenominationParams = denominationParamApi;
            _apiParameter = parameterApi;
        }

        public IActionResult Index(int id, string title, int serviceTypeId, int page = 1, int size = 10, bool processSucceded = false)
        {
            var data = _apiDenomination.ApiDenominationGetDenominationsByServiceIdServiceIdGet(id, page, size, "ar");

            var viewModel = new PagedResult<DenominationViewModel>
            {
                Results = data.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            ViewBag.FullTitle = title;
            ViewBag.serviceTypeId = serviceTypeId;
            ViewBag.serviceId = id;
            ViewBag.processSucceded = processSucceded;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create(int serviceId, int serviceTypeId)
        {
            ViewBag.ServicesProvider = _apiServiceProvider.ApiServiceProviderGetServiceProviderGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = a.Name.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.ServiceConfiguartion = _apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsGet(1, 200).Results.Select(a => new SelectListItem
            {
                Text = a.Url.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.DenominationParamters = _apiDenominationParams.ApiDenominationParamGetParamsGet(1, 200).Results.Select(a => new SelectListItem
            {
                Text = (a.Label + " - " + a.ValueModeName + " - " + a.ValueTypeName + " - " + a.ParamKey).ToString(),
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.Parameters = _apiParameter.ApiParameterGetParamtersGet(1, 200).Results.Select(a => new SelectListItem
            {
                Text = a.ProviderName.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateDenominationViewModel
            {
                Denomination = new DenominationViewModel() { ServiceID = serviceId, ServiceTypeID = serviceTypeId },
                DenominationServiceProviders = new DenominationServiceProvidersViewModel(),
                ServiceConfigeration = new ServiceConfigerationViewModel(),
                DenominationParameter = new DenominationParameterViewModel(),
                DenominationReceipt = new DenominationReceiptViewModel()
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

                ViewBag.ServicesProvider = _apiServiceProvider.ApiServiceProviderGetServiceProviderGet(1, 100).Results.Select(a => new SelectListItem
                {
                    Text = a.Name.ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                ViewBag.ServiceConfiguartion = _apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsGet(1, 200).Results.Select(a => new SelectListItem
                {
                    Text = a.Url.ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                ViewBag.DenominationParamters = _apiDenominationParams.ApiDenominationParamGetParamsGet(1, 200).Results.Select(a => new SelectListItem
                {
                    Text = (a.Label + " - " + a.ValueModeName + " - " + a.ValueTypeName + " - " + a.ParamKey).ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                return View(model);
            }

            _apiDenomination.ApiDenominationAddDenominationPost(new AddDenominationModel()
            {
                Denomination = MapToModel(model.Denomination),
                DenominationServiceProviders = MapToModel(model.DenominationServiceProviders),
                ServiceConfigeration = MapToModel(model.ServiceConfigeration),
                DenominationParameter = MapToModel(model.DenominationParameter),
                DenominationReceiptData = MapToModel(model.DenominationReceipt.DenominationReceiptData),
                DenominationReceiptParams = model.DenominationReceipt.DenominationReceiptParams.Select(x => MapToModel(x)).ToList()
            });

            return RedirectToAction(nameof(Index), new { id = model.Denomination.ServiceID, processSucceded = true });
        }

        [HttpPost]
        public JsonResult CreateServiceConfiguartion(ServiceConfigerationViewModel model)
        {
            var viewModel = _apiServiceConfiguration.ApiServiceConfigurationAddServiceConfiguartionsPost(new ServiceConfigerationModel
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
            ViewBag.ServicesProvider = _apiServiceProvider.ApiServiceProviderGetServiceProviderGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = a.Name.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.ServiceConfiguartion = _apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsGet(1, 200).Results.Select(a => new SelectListItem
            {
                Text = a.Url.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.DenominationParamters = _apiDenominationParams.ApiDenominationParamGetParamsGet(1, 200).Results.Select(a => new SelectListItem
            {
                Text = (a.Label + " - " + a.ValueModeName + " - " + a.ValueTypeName + " - " + a.ParamKey).ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var parameters = _apiParameter.ApiParameterGetParamtersGet(1, 200).Results.Select(a => new SelectListItem
            {
                Text = a.ProviderName.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.Parameters = new SelectList(parameters, "Value", "Text");

            var model = _apiDenomination.ApiDenominationGetDenominationByIdIdGet(id);

            var viewModel = new EditDenominationViewModel
            {
                DenominationID = (int)model.Denomination.Id,
                DenominationReceiptDataID = (int)model.DenominationReceipt.DenominationReceiptData.Id,
                Denomination = MapToViewModel(model.Denomination),
                DenominationServiceProvidersViewModels = model.DenominationServiceProviders.Select(x => MapToViewModel(x)).ToList(),
                DenominationParameters = model.DenominationParameters.Select(x => MapToViewModel(x)).ToList(),
                DenominationReceipt = new DenominationReceiptViewModel
                {
                    DenominationReceiptData = MapToViewModel(model.DenominationReceipt.DenominationReceiptData),
                    DenominationReceiptParams = model.DenominationReceipt.DenominationReceiptParams.Select(x => MapToViewModel(x)).ToList()
                }
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

            _apiDenomination.ApiDenominationEditDenominationPut(MapToModel(model.Denomination));

            return RedirectToAction(nameof(Index), new { id = model.Denomination.ServiceID });
        }

        [HttpGet]
        public IActionResult ChangeStatus(int id, int serviceId, string title, int serviceTypeId)
        {
            _apiDenomination.ApiDenominationChangeStatusPut(id);
            return RedirectToAction(nameof(Index), new { id = serviceId, serviceTypeId, title });
        }
        [HttpGet]
        public JsonResult ChangeStatusDenominationServiceProvider(int id)
        {
            try
            {
                _apiDenomination.ApiDenominationChangeDenominationServiceProviderStatusPut(id);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        [HttpGet]
        public JsonResult GetDenominationServiceProvidersByDenomniationId(int denomniationId)
        {
            try
            {
                var result = _apiDenomination.ApiDenominationGetDenominationServiceProvidersByDenominationIdDenominationIdGet(denomniationId);
                return Json(result.Select(x => MapToViewModel(x)));
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpGet]
        public JsonResult EditDenominationServiceProvider(int id)
        {
            //ViewBag.ServicesProvider = apiServiceProvider.ApiServiceProviderGetServiceProviderGet(1, 100).Results.Select(a => new SelectListItem
            //{
            //    Text = a.Name.ToString(),
            //    Value = a.Id.ToString()
            //}).ToList();

            //ViewBag.ServiceConfiguartion = apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsGet(1, 200).Results.Select(a => new SelectListItem
            //{
            //    Text = a.Url.ToString(),
            //    Value = a.Id.ToString()
            //}).ToList();

            var model = _apiDenomination.ApiDenominationGetDenominationServiceProviderByDenominationIdIdGet(id);

            return Json(MapToViewModel(model));
        }

        [HttpPost]
        public JsonResult EditDenominationServiceProvider([FromForm] DenominationServiceProvidersViewModel model)
        {
            var viewModel = _apiDenomination.ApiDenominationEditDenominationServiceProviderPut(MapToModel(model));

            return Json(MapToViewModel(viewModel));
        }
        [HttpPost]
        public JsonResult AddDenominationServiceProvider([FromForm] DenominationServiceProvidersViewModel model)
        {
            var viewModel = _apiDenomination.ApiDenominationAddDenominationServiceProvdierPost(MapToModel(model));

            return Json(MapToViewModel(viewModel));
        }

        [HttpPost]
        public JsonResult AddDenominationParameter(DenominationParameterViewModel model)
        {
            var viewModel = _apiDenomination.ApiDenominationAddDenominationParameterPost(MapToModel(model));

            return Json(MapToViewModel(viewModel));
        }
        [HttpGet]
        public JsonResult EditDenominationParameter(int id)
        {
            ViewBag.DenominationParamters = _apiDenominationParams.ApiDenominationParamGetParamsGet(1, 200).Results.Select(a => new SelectListItem
            {
                Text = (a.Label + " - " + a.ValueModeName + " - " + a.ValueTypeName + " - " + a.ParamKey).ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var model = _apiDenomination.ApiDenominationGetDenominationParameterByIdIdGet(id);

            return Json(MapToViewModel(model));
        }
        [HttpPost]
        public JsonResult EditDenominationParameter(DenominationParameterViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.DenominationParamters = apiDenominationParams.ApiDenominationParamGetParamsGet(1, 200).Results.Select(a => new SelectListItem
            //    {
            //        Text = (a.Label + " - " + a.ValueModeName + " - " + a.ValueTypeName + " - " + a.ParamKey).ToString(),
            //        Value = a.Id.ToString()
            //    }).ToList();

            //    return Json(model);
            //}

            var viewModel = _apiDenomination.ApiDenominationEditDenominationParameterPut(MapToModel(model));

            return Json(MapToViewModel(viewModel));
        }
        [HttpGet]
        public JsonResult DeleteDenominationParameter(int id, int denominationId)
        {
            _apiDenomination.ApiDenominationDeleteDenominationParameterIdDelete(id);
            return Json(id);
        }
        [HttpGet]
        public IActionResult EditDenominationReceiptParam(int id)
        {
            ViewBag.Parameters = _apiParameter.ApiParameterGetParamtersGet(1, 200).Results.Select(a => new SelectListItem
            {
                Text = a.ProviderName.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var model = _apiDenomination.ApiDenominationGetDenominationReceiptParamByIdIdGet(id);

            return View(MapToViewModel(model));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDenominationReceiptParam(DenominationReceiptParamViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Parameters = _apiParameter.ApiParameterGetParamtersGet(1, 200).Results.Select(a => new SelectListItem
                {
                    Text = a.ProviderName.ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                return View(model);
            }

            _apiDenomination.ApiDenominationEditDenominationReceiptParamPut(MapToModel(model));

            return RedirectToAction(nameof(Edit), new { id = model.DenominationID });
        }
        [HttpGet]
        public IActionResult ChangeStatusDenominationReceiptParam(int id, int denominationId)
        {
            _apiDenomination.ApiDenominationChangeDenominationReceiptParamStatusPut(id);
            return RedirectToAction(nameof(Edit), new { id = denominationId });
        }
        [HttpPost]
        public JsonResult EditDenominationRecepit([FromForm] DenominationReceiptViewModel model)
        {
            model.DenominationReceiptData.DenominationID = model.DenominationID;
            model.DenominationReceiptData.Id = model.DenominationReceiptDataID;
            _apiDenomination.ApiDenominationEditDenominationReceiptPut(new DenominationReceiptModel
            {
                DenominationReceiptData = MapToModel(model.DenominationReceiptData),
                DenominationReceiptParams = model.DenominationReceiptParams.Select(x => MapToModel(x)).ToList()
            });
            return Json(model);
        }
        [HttpPost]
        public JsonResult AddDenominationParam(DenominationParamViewModel model)
        {
            var viewModel = _apiDenominationParams.ApiDenominationParamAddParamPost(MapToModel(model));
            return Json(MapToViewModel(viewModel));
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
                ServiceName = denomination.ServiceName,
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
                ServiceConfigerationId = model.ServiceConfigerationID,
                Status = model.Status,
                DenominationId = model.DenominationID,
                DenominationProviderConfigurationModel = model.DenominationProviderConfigurations.Select(x => MapToModel(x)).ToList()
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
                ServiceConfigerationID = (int)model.ServiceConfigerationId, //Edit
                DenominationProviderConfigurations = model.DenominationProviderConfigurationModel?.Select(x => MapToViewModel(x)).ToList()
            };
        }
        private DenominationProviderConfigerationModel MapToModel(DenominationProviderConfigurationViewModel model)
        {
            return new DenominationProviderConfigerationModel
            {
                Id = model.ID,
                Name = model.Name,
                Value = model.Value,
                DenominationProviderID = model.DenominationProviderID
            };
        }
        private DenominationProviderConfigurationViewModel MapToViewModel(DenominationProviderConfigerationModel model)
        {
            return new DenominationProviderConfigurationViewModel
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
        private DenominationParameterViewModel MapToViewModel(DenominationParameterModel model)
        {
            return new DenominationParameterViewModel
            {
                Id = (int)model.Id,
                DenominationID = (int)model.DenominationID,
                Optional = (bool)model.Optional,
                Sequence = (int)model.Sequence,
                ValidationExpression = model.ValidationExpression,
                ValidationMessage = model.ValidationMessage,
                ValidationMessageAr = model.ValidationMessageAr,
                DenominationParamID = (int)model.DenominationParamID,
                Value = model.Value,
                ValueList = model.ValueList
            };
        }
        private DenominationParameterModel MapToModel(DenominationParameterViewModel model)
        {
            return new DenominationParameterModel
            {
                Id = model.Id,
                DenominationID = model.DenominationID,
                Optional = model.Optional,
                Sequence = model.Sequence,
                ValidationExpression = model.ValidationExpression,
                ValidationMessage = model.ValidationMessage,
                ValidationMessageAr = model.ValidationMessageAr,
                DenominationParamID = model.DenominationParamID,
                Value = model.Value,
                ValueList = model.ValueList
            };
        }
        private DenominationReceiptDataViewModel MapToViewModel(DenominationReceiptDataModel model)
        {
            return new DenominationReceiptDataViewModel
            {
                Id = (int)model.Id,
                DenominationID = (int)model.DenominationID,
                Title = model.Title,
                Disclaimer = model.Disclaimer,
                Footer = model.Footer
            };
        }
        private DenominationReceiptDataModel MapToModel(DenominationReceiptDataViewModel model)
        {
            return new DenominationReceiptDataModel
            {
                Id = model.Id,
                DenominationID = model.DenominationID,
                Title = model.Title,
                Disclaimer = model.Disclaimer,
                Footer = model.Footer
            };
        }
        private DenominationReceiptParamViewModel MapToViewModel(DenominationReceiptParamModel model)
        {
            return new DenominationReceiptParamViewModel
            {
                Id = (int)model.Id,
                DenominationID = (int)model.DenominationID,
                ParameterID = (int)model.ParameterID,
                ParameterName = model.ParameterName,
                Bold = (bool)model.Bold,
                Alignment = (int)model.Alignment,
                Status = (bool)model.Status,
                DenominationReceiptDataID = model.DenominationReceiptDataID,
                FontSize = model.FontSize
            };
        }
        private DenominationReceiptParamModel MapToModel(DenominationReceiptParamViewModel model)
        {
            return new DenominationReceiptParamModel
            {
                Id = model.Id,
                DenominationID = model.DenominationID,
                ParameterID = model.ParameterID,
                Bold = model.Bold,
                Alignment = model.Alignment,
                Status = model.Status,
                FontSize = model.FontSize,
            };
        }
        private DenominationParamViewModel MapToViewModel(DenominationParamModel model)
        {
            return new DenominationParamViewModel
            {
                Id = (int)model.Id,
                Label = model.Label,
                Title = model.Title,
                ParamKey = model.ParamKey,
                ValueModeID = (DenominationParamsValueMode)model.ValueModeID,
                ValueModeName = model.ValueModeName,
                ValueTypeID = (DenominationParamsValueType)model.ValueTypeID,
                ValueTypeName = model.ValueTypeName,
            };
        }
        private DenominationParamModel MapToModel(DenominationParamViewModel model)
        {
            return new DenominationParamModel
            {
                Id = model.Id,
                Label = model.Label,
                Title = model.Title,
                ParamKey = model.ParamKey,
                ValueModeID = ((int)model.ValueModeID),
                ValueModeName = model.ValueModeName,
                ValueTypeID = ((int)model.ValueTypeID),
                ValueTypeName = model.ValueTypeName
            };
        }
    }
}
