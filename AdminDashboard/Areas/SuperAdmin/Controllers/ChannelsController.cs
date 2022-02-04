using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ChannelsController : Controller
    {
        private readonly IChannelApi _api;
        private readonly IChannelCategoryApi _channelCategoryApi;
        private readonly IChannelTypeApi _channelTypeApi;
        private readonly IChannelOwnerApi _channelOwnerApi;
        private readonly IChannelPaymentMethodApi _channelPaymentMethodApi;
        public ChannelsController(IChannelApi channelApi, 
            IChannelCategoryApi channelCategoryApi, 
            IChannelTypeApi channelTypeApi, 
            IChannelOwnerApi channelOwnerApi,
            IChannelPaymentMethodApi channelPaymentMethodApi)
        {
            
            _api = channelApi;
            _channelCategoryApi = channelCategoryApi;
            _channelTypeApi = channelTypeApi;
            _channelOwnerApi = channelOwnerApi;
            _channelPaymentMethodApi = channelPaymentMethodApi;

        }
        // GET: ChannelsController
        [HttpGet]
        public IActionResult Index()
        {
            var data = _channelCategoryApi.ApiChannelCategoryGetAllGet();

            ViewBag.ChannelCategoryList = data.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            return View(new PagedResult<ChannelViewModel>());
        }
        [HttpGet]
        public IActionResult SearchChannels(int? dropDownFilter, int? dropDownFilter2, string searchKey = null, int page = 1)
        {
            var data = _api.ApiChannelSearchChannelsGet(dropDownFilter, dropDownFilter2, searchKey, page, 10);

            var viewModel = new PagedResult<ChannelViewModel>
            {
                Results = data.Results.Select(account => Map(account)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = 10
            };

            ViewBag.ChannelCategoryList = _channelCategoryApi.ApiChannelCategoryGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            return View("Index", viewModel);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var channelTypes = _channelTypeApi.ApiChannelTypeGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var channelOwners = _channelOwnerApi.ApiChannelOwnerGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var channelPaymentMethods = _channelPaymentMethodApi.ApiChannelPaymentMethodGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateChannelViewModel
            {
                ChannelTypes = channelTypes,
                ChannelOwners = channelOwners,
                PaymentMethods = channelPaymentMethods
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateChannelViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var channelTypes = _channelTypeApi.ApiChannelTypeGetAllGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var channelOwners = _channelOwnerApi.ApiChannelOwnerGetAllGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var channelPaymentMethods = _channelPaymentMethodApi.ApiChannelPaymentMethodGetAllGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                model = new CreateChannelViewModel
                {
                    ChannelTypes = channelTypes,
                    ChannelOwners = channelOwners,
                    PaymentMethods = channelPaymentMethods
                };

                return View(model);
            }

            try
            {
                var result = _api.ApiChannelAddPost(new AddChannelModel
                      (
                      name: model.Name,
                      channelTypeID: model.ChannelTypeID,
                      channelOwnerID: model.ChannelOwnerID,
                      serial: model.Serial,
                      paymentMethodID: model.PaymentMethodID,
                      value: model.Value,
                      status: model.Status,
                      accountId: model.AccountId
                      ));

                //save changes
                if (result != null)
                {
                    TempData["result"] = true;
                    return RedirectToAction(nameof(Index));
                }

                return View(model);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var channelTypes = _channelTypeApi.ApiChannelTypeGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var channelOwners = _channelOwnerApi.ApiChannelOwnerGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();
            var channelPaymentMethods = _channelPaymentMethodApi.ApiChannelPaymentMethodGetAllGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var model = _api.ApiChannelGetChannelIdentitfiersChannelIdGet(id);
            var viewModel = Map(model);
            viewModel.ChannelTypes = channelTypes;
            viewModel.ChannelOwners = channelOwners;
            viewModel.PaymentMethods = channelPaymentMethods;

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ChannelViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var channelTypes = _channelTypeApi.ApiChannelTypeGetAllGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var channelOwners = _channelOwnerApi.ApiChannelOwnerGetAllGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();
                var channelPaymentMethods = _channelPaymentMethodApi.ApiChannelPaymentMethodGetAllGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                model = new ChannelViewModel
                {
                    ChannelTypes = channelTypes,
                    ChannelOwners = channelOwners,
                    PaymentMethods = channelPaymentMethods
                };
                return View(model);
            }

            try
            {
                var result = _api.ApiChannelEditPut(new EditChannelModel(
                     channelId: model.Id,
                     name: model.Name,
                       channelTypeID: model.ChannelTypeID,
                       channelOwnerID: model.ChannelOwnerID,
                       serial: model.Serial,
                       paymentMethodID: model.PaymentMethodID,
                       value: model.Value,
                       status: model.Status
                     ));

                if (result != null)
                {
                    TempData["result"] = true;
                    return RedirectToAction(nameof(Index));
                }

                return View(model);

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
            _api.ApiChannelDeleteIdDelete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            _api.ApiChannelChangeStatusIdGet(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public JsonResult GetChannelTypesByChannelCategoryId(int id)
        {
            var accounts = _channelTypeApi.ApiChannelTypeGetByChannelCategoryIdGet(id);
            return Json(accounts);
        }
        [HttpPost]
        public JsonResult CreateChannelJson(CreateChannelViewModel model)
        {
            try
            {
                var result = _api.ApiChannelAddPost(new AddChannelModel
                      (
                      name: model.Name,
                      channelTypeID: model.ChannelTypeID,
                      channelOwnerID: model.ChannelOwnerID,
                      serial: model.Serial,
                      paymentMethodID: model.PaymentMethodID,
                      value: model.Value,
                      status: model.Status,
                      accountId: model.AccountId
                      ));
                return Json(result);

            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
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
