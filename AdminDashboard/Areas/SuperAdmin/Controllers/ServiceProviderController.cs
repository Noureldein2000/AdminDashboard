using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Route("SuperAdmin/[controller]/{action}/{id?}")]
    [Authorize]
    public class ServiceProviderController : Controller
    {
        private readonly IServiceProviderApi _apiServiceProvider;
        public ServiceProviderController(IServiceProviderApi serviceProviderApi)
        {
            _apiServiceProvider = serviceProviderApi;
        }

        public async Task<IActionResult> Index(int page = 1, int size = 10, bool processSucceded = false)
        {
            var data = await _apiServiceProvider.ApiServiceProviderGetServiceProviderGetAsync(page, size);

            var viewModel = new PagedResult<ServiceProviderViewModel>
            {
                Results = data.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = size
            };
            ViewBag.processSucceded = processSucceded;
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View(new ServiceProviderViewModel());
        }
        [HttpPost]
        public IActionResult Create(ServiceProviderViewModel model)
        {
            try
            {
                var result = _apiServiceProvider.ApiServiceProviderAddServiceProviderPost(MapToModel(model));
                return Json(MapToViewModel(result));

            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message.Remove(0, ex.Message.IndexOf('{'));
                return Json(JsonConvert.DeserializeObject<ExceptionErrorMessage>(errorMessage));
            }

        }
        public IActionResult Edit(int id)
        {
            var model = _apiServiceProvider.ApiServiceProviderGetServiceProviderByIdIdGet(id);
            return View(MapToViewModel(model));
        }

        [HttpPost]
        public IActionResult Edit(ServiceProviderViewModel model)
        {
            try
            {

                _apiServiceProvider.ApiServiceProviderEditServiceProviderPut(MapToModel(model));
                return Json(model);
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message.Remove(0, ex.Message.IndexOf('{'));
                return Json(JsonConvert.DeserializeObject<ExceptionErrorMessage>(errorMessage));
            }
        }
        public JsonResult Delete(int id)
        {
            _apiServiceProvider.ApiServiceProviderDeleteServiceProviderIdDelete(id);
            return Json(id);
        }


        private ServiceProviderViewModel MapToViewModel(ServiceProviderModel model)
        {
            return new ServiceProviderViewModel
            {
                Id = (int)model.Id,
                Name = model.Name
            };
        }
        private ServiceProviderModel MapToModel(ServiceProviderViewModel model)
        {
            return new ServiceProviderModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
