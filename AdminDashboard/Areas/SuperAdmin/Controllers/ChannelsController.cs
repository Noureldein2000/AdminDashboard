using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using AdminDashboard.SwaggerClienti;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ChannelsController : Controller
    {
        private readonly IChannelApi api;
        private readonly IChannelTypeApi channelTypeApi;
        private readonly IChannelOwnerApi channelOwnerApi;
        private readonly IChannelPaymentMethodApi channelPaymentMethodApi;
        public ChannelsController()
        {
            string url = "https://localhost:44303";
            api = new ChannelApi(url);
            channelTypeApi = new ChannelTypeApi(url);
            channelOwnerApi = new ChannelOwnerApi(url);
            channelPaymentMethodApi = new ChannelPaymentMethodApi(url);

        }
        // GET: ChannelsController
        [HttpGet]
        public IActionResult Index(string searchKey, int page = 1)
        {
            ChannelResponseModelPagedResult data;

            if (!string.IsNullOrEmpty(searchKey))
                data = api.ApiChannelSearchChannelBySerialSearchKeyGet(searchKey, page, 10);
            else
                data = api.ApiChannelGetChannelsGet(page, 10);

            var dd = data.Results.Select(account => Map(account)).ToList();
            var viewModel = new PagedResult<ChannelViewModel>
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
                var result = api.ApiChannelAddPost(new AddChannelModel
                      (
                      name: model.Name,
                      channelTypeID: model.ChannelTypeID,
                      channelOwnerID: model.ChannelOwnerID,
                      serial: model.Serial,
                      paymentMethodID: model.PaymentMethodID,
                      value: model.Value,
                      status: model.Status
                      ));

                //save changes
                if (result != null)
                    return RedirectToAction(nameof(Index));

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

            var model = api.ApiChannelGetChannelIdentitfiersChannelIdGet(id);
            var viewModel = Map(model);
            viewModel.ChannelTypes = channelTypes;
            viewModel.ChannelOwners = channelOwners;
            viewModel.PaymentMethods = channelPaymentMethods;

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(ChannelViewModel model)
        {
            if (!ModelState.IsValid)
            {
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
                var result = api.ApiChannelEditPut(new EditChannelModel(
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
                    return RedirectToAction(nameof(Index));

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
            api.ApiChannelDeleteIdDelete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            api.ApiChannelChangeStatusIdGet(id);
            return RedirectToAction(nameof(Index));
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
