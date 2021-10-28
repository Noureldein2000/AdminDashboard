using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class ServiceProviderController : Controller
    {
        private readonly IAdminServiceApi apiAdminService;
        private readonly IDenominationApi apiDenomination;
        private readonly IServiceProviderApi apiServiceProvider;
        public ServiceProviderController(
            )
        {
            //string urlIdentity = "https://localhost:44303";
            string urlTms = "https://localhost:44321";
            apiAdminService = new AdminServiceApi(urlTms);
            apiDenomination = new DenominationApi(urlTms);
            apiServiceProvider = new ServiceProviderApi(urlTms);
        }

        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var data = await apiServiceProvider.ApiServiceProviderGetServiceProviderGetAsync(page, size);

            var viewModel = new PagedResult<ServiceProviderViewModel>
            {
                Results = data.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            return View(viewModel);
        }


        private ServiceProviderViewModel MapToViewModel(ServiceProviderModel denomination)
        {
            return new ServiceProviderViewModel
            {
                Id = (int)denomination.Id,
                Name = denomination.Name
            };
        }
    }
}
