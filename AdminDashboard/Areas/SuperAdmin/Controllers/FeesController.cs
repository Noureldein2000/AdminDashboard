﻿using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Helper;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Route("SuperAdmin/[controller]/{action}/{id?}")]
    [Authorize]
    public class FeesController : Controller
    {
        private readonly IAccountApi api;
        private readonly IFeesApi apiFees;
        private readonly IConfiguration _configuration;
        public FeesController(IConfiguration configuration)
        {
            _configuration = configuration;
            string url = _configuration.GetValue<string>("Urls:Authority");
            string urlTms = _configuration.GetValue<string>("Urls:TMS");
            api = new AccountApi(url);
            apiFees = new FeesApi(urlTms);
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var data = await apiFees.ApiFeesGetFeesGetAsync(page, pageSize);

            var viewModel = new PagedResult<FeesViewModel>
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
            return View(new FeesViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FeesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            apiFees.ApiFeesAddFeePost(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = apiFees.ApiFeesGetFeeByIdIdGet(id);
            return View(Map(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FeesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            apiFees.ApiFeesEditFeePut(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            apiFees.ApiFeesChangeStatusIdPut(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            apiFees.ApiFeesDeleteFeeIdDelete(id);
            return Json(id);
        }

        private FeesViewModel Map(FeesModel x)
        {
            return new FeesViewModel
            {
                ID = (int)x.Id,
                FeesTypeID = (FeesType)x.FeesTypeID,
                AmountFrom = (decimal)x.AmountFrom,
                AmountTo = (decimal)x.AmountTo,
                CreatedBy = (int)x.CreatedBy,
                FeesTypeName = x.FeesTypeName,
                PaymentModeName = x.PaymentModeName,
                PaymentModeID = (PaymentMode)x.PaymentModeID,
                Status = (bool)x.Status,
                Value = (decimal)x.Value,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
            };
        }

        private FeesModel MapToModel(FeesViewModel x)
        {
            return new FeesModel
            {
                Id = (int)x.ID,
                FeesTypeID = ((int)x.FeesTypeID),
                AmountFrom = (double)x.AmountFrom,
                AmountTo = (double)x.AmountTo,
                CreatedBy = (int)x.CreatedBy,
                FeesTypeName = x.FeesTypeName,
                PaymentModeName = x.PaymentModeName,
                PaymentModeID = (int)x.PaymentModeID,
                Status = x.Status,
                Value = (double)x.Value,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
            };
        }

    }
}
