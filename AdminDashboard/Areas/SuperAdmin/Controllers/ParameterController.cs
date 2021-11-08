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
    public class ParameterController : Controller
    {
        private readonly IParameterApi apiParameter;
        private readonly IConfiguration _configuration;
        public ParameterController(IConfiguration configuration)
        {
            _configuration = configuration;
            string url = _configuration.GetValue<string>("Urls:Authority");
            string urlTms = _configuration.GetValue<string>("Urls:TMS");
            apiParameter = new ParameterApi(urlTms);
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var data = await apiParameter.ApiParameterGetParamtersGetAsync(page, pageSize);

            var viewModel = new PagedResult<ParameterViewModel>
            {
                Results = data.Results.Select(u => Map(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = pageSize
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new ParameterViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ParameterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            apiParameter.ApiParameterAddParameterPost(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = apiParameter.ApiParameterGetParamterByIdIdGet(id);
            return View(Map(model));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ParameterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            apiParameter.ApiParameterEditParameterPut(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            apiParameter.ApiParameterDeleteParameterIdDelete(id);
            return RedirectToAction(nameof(Index));
        }

        private ParameterViewModel Map(ParametersModel x)
        {
            return new ParameterViewModel
            {
                Id = (int)x.Id,
                Name = x.Name,
                NameAr = x.NameAr,
                ProviderName = x.ProviderName,
            };
        }

        private ParametersModel MapToModel(ParameterViewModel x)
        {
            return new ParametersModel
            {
                Id = x.Id,
                Name = x.Name,
                NameAr = x.NameAr,
                ProviderName = x.ProviderName,
            };
        }
    }
}
