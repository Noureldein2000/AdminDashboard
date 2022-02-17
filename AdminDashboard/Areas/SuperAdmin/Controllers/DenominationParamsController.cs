using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Helper;
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
    public class DenominationParamsController : Controller
    {
        private readonly IAccountApi _api;
        private readonly IDenominationParamApi _apiDenominationParam;
        public DenominationParamsController(IAccountApi accountApi, IDenominationParamApi denominationParamApi)
        {
            _api = accountApi;
            _apiDenominationParam = denominationParamApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, bool processSucceded = false)
        {
            var data = await _apiDenominationParam.ApiDenominationParamGetParamsGetAsync(page, pageSize);

            var viewModel = new PagedResult<DenominationParamViewModel>
            {
                Results = data.Results.Select(u => Map(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = pageSize
            };
            ViewBag.processSucceded = processSucceded;
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

            _apiDenominationParam.ApiDenominationParamAddParamPost(MapToModel(model));
            return RedirectToAction(nameof(Index), new { processSucceded = true });
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _apiDenominationParam.ApiDenominationParamGetParamByIdIdGet(id);

            return View(Map(model));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DenominationParamViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _apiDenominationParam.ApiDenominationParamEditParamPut(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            _apiDenominationParam.ApiDenominationParamDeleteParamIdDelete(id);
            return Json(id);
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
