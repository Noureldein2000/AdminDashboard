using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Helper;
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
    public class DenominationParamsController : Controller
    {
        private readonly IAccountApi api;
        private readonly IDenominationParamApi apiDenominationParam;
        public DenominationParamsController(
            )
        {
            string url = "https://localhost:44303";
            string urlTms = "https://localhost:44321";
            api = new AccountApi(url);
            apiDenominationParam = new DenominationParamApi(urlTms);
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var data = await apiDenominationParam.ApiDenominationParamGetParamsGetAsync(page, pageSize);

            var viewModel = new PagedResult<DenominationParamViewModel>
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
            return View(new DenominationParamViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DenominationParamViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            apiDenominationParam.ApiDenominationParamAddParamPost(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = apiDenominationParam.ApiDenominationParamGetParamByIdIdGet(id);

            return View(Map(model));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DenominationParamViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            apiDenominationParam.ApiDenominationParamEditParamPut(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            apiDenominationParam.ApiDenominationParamDeleteParamIdDelete(id);
            return RedirectToAction(nameof(Index));
        }


        private DenominationParamViewModel Map(DenominationParamModel model)
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
