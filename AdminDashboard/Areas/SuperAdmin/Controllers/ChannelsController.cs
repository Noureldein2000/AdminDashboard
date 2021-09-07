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
        private readonly IChannelCategoryApi channelCategoryApi;
        private readonly IChannelTypeApi channelTypeApi;
        private readonly IChannelOwnerApi channelOwnerApi;
        private readonly IChannelPaymentMethodApi channelPaymentMethodApi;
        public ChannelsController()
        {
            string url = "https://localhost:44303";
            api = new ChannelApi(url);
            channelCategoryApi = new ChannelCategoryApi(url);
            channelTypeApi = new ChannelTypeApi(url);
            channelOwnerApi = new ChannelOwnerApi(url);
            channelPaymentMethodApi = new ChannelPaymentMethodApi(url);

        }
        // GET: ChannelsController
        [HttpGet]
        public IActionResult Index()
        {
            var data = channelCategoryApi.ApiChannelCategoryGetAllGet();

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
            var data = api.ApiChannelSearchChannelsGet(dropDownFilter, dropDownFilter2, searchKey, page, 10);
            var dd = data.Results.Select(account => Map(account)).ToList();
            var viewModel = new PagedResult<ChannelViewModel>
            {
                Results = dd,
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = 10
            };


            var channelCategories = channelCategoryApi.ApiChannelCategoryGetAllGet();

            ViewBag.ChannelCategoryList = channelCategories.Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            return View("Index", viewModel);
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
        [ValidateAntiForgeryToken]
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
                      status: model.Status,
                      accountId: model.AccountId
                      ));

                //save changes
                if (result != null)
                {
                    TempData["result"] = true;
                    //return Ok();
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
        [ValidateAntiForgeryToken]
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
            api.ApiChannelDeleteIdDelete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            api.ApiChannelChangeStatusIdGet(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public JsonResult GetChannelTypesByChannelCategoryId(int id)
        {
            var accounts = channelTypeApi.ApiChannelTypeGetByChannelCategoryIdGet(id);
            return Json(accounts);
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
