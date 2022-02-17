using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
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
    public class ServiceConfiguarationController : Controller
    {
        private readonly IAdminServiceApi _api;
        private readonly IDenominationApi _apiDenomination;
        private readonly IServiceProviderApi _apiServiceProvider;
        private readonly IServiceConfigurationApi _apiServiceConfiguration;
        public ServiceConfiguarationController(IAdminServiceApi adminServiceApi,
            IDenominationApi denominationApi,
            IServiceProviderApi serviceProviderApi,
            IServiceConfigurationApi serviceConfigurationApi)
        {
            _api = adminServiceApi;
            _apiDenomination = denominationApi;
            _apiServiceProvider = serviceProviderApi;
            _apiServiceConfiguration = serviceConfigurationApi;
        }
        public async Task<IActionResult> Index(int page = 1, int size = 10, bool processSucceded = false)
        {
            var data = await _apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsGetAsync(page, size);

            var viewModel = new PagedResult<ServiceConfigerationViewModel>
            {
                Results = data.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = size
            };
            ViewBag.processSucceded = processSucceded;
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new ServiceConfigerationViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceConfigerationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _apiServiceConfiguration.ApiServiceConfigurationAddServiceConfiguartionsPost(MapToModel(model));

            return RedirectToAction(nameof(Index), new { processSucceded = true });
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsByIdIdGet(id);
            return View(MapToViewModel(model));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceConfigerationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _apiServiceConfiguration.ApiServiceConfigurationEditServiceConfiguartionsPut(MapToModel(model));

            return RedirectToAction(nameof(Index));
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
        private ServiceConfigParmsViewModel MapToViewModel(ServiceConfigParmsModel model)
        {
            return new ServiceConfigParmsViewModel
            {
                Id = (int)model.Id,
                Name = model.Name,
                Value = model.Value
            };
        }
    }
}
