using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ServiceProviderController : Controller
    {
        private readonly IServiceProviderApi _apiServiceProvider;
        public ServiceProviderController(IServiceProviderApi serviceProviderApi)
        {
            _apiServiceProvider = serviceProviderApi;
        }

        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var data = await _apiServiceProvider.ApiServiceProviderGetServiceProviderGetAsync(page, size);

            var viewModel = new PagedResult<ServiceProviderViewModel>
            {
                Results = data.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View(new ServiceProviderViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceProviderViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _apiServiceProvider.ApiServiceProviderAddServiceProviderPost(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var model = _apiServiceProvider.ApiServiceProviderGetServiceProviderByIdIdGet(id);
            return View(MapToViewModel(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceProviderViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _apiServiceProvider.ApiServiceProviderEditServiceProviderPut(MapToModel(model));
            return RedirectToAction(nameof(Index));
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
