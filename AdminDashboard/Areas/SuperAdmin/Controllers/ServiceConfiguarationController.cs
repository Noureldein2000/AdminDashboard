using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IAdminServiceApi api;
        private readonly IDenominationApi apiDenomination;
        private readonly IServiceProviderApi apiServiceProvider;
        private readonly IServiceConfigurationApi apiServiceConfiguration;
        public ServiceConfiguarationController(
            )
        {
            //string urlIdentity = "https://localhost:44303";
            string urlTms = "https://localhost:44321";
            api = new AdminServiceApi(urlTms);
            apiDenomination = new DenominationApi(urlTms);
            apiServiceProvider = new ServiceProviderApi(urlTms);
            apiServiceConfiguration = new ServiceConfigurationApi(urlTms);
        }
        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var data = await apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsGetAsync(page, size);

            var viewModel = new PagedResult<ServiceConfigerationViewModel>
            {
                Results = data.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = size
            };

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

            apiServiceConfiguration.ApiServiceConfigurationAddServiceConfiguartionsPost(MapToModel(model));

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = apiServiceConfiguration.ApiServiceConfigurationGetServiceConfiguartionsByIdIdGet(id);
            return View(MapToViewModel(model));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServiceConfigerationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            apiServiceConfiguration.ApiServiceConfigurationEditServiceConfiguartionsPut(MapToModel(model));

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
