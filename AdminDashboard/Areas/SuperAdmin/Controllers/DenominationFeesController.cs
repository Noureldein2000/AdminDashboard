﻿using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class DenominationFeesController : Controller
    {
        private readonly IFeesApi _apiFees;
        private readonly IDenominationFeesApi _apiDenominationFees;
        private readonly IDenominationApi _apiDenomination;
        public DenominationFeesController(IFeesApi feesApi, IDenominationFeesApi denominationFeesApi, IDenominationApi denominationApi)
        {
            _apiFees = feesApi;
            _apiDenominationFees = denominationFeesApi;
            _apiDenomination = denominationApi;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int denominationId)
        {
            var data = await _apiDenominationFees.ApiDenominationFeesGetdenominationFeesByDenominationIdDenominationIdGetAsync(denominationId);
            ViewBag.denominationId = denominationId;
            return View(data.Select(x => Map(x)));
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var fees = _apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = a.FeeRange.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateDenominationFeesViewModel
            {
                DenominationId = id,
                Fees = fees,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateDenominationFeesViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var fees = _apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
                    {
                        Text = a.Value.ToString(),
                        Value = a.Id.ToString()
                    }).ToList();

                    model.Fees = fees;

                    return View(model);
                }

                _apiDenominationFees.ApiDenominationFeesAddDenominationFeesPost(new AddDenominationFeesModel(
                    denominationId: model.DenominationId,
                    feesId: model.FeesId));

                return RedirectToAction(nameof(Index), new { denominationId = model.DenominationId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
           
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            _apiDenominationFees.ApiDenominationFeesDeleteDenominationFeeIdDelete(id: id);

            return Json(id);
        }

        private DenominationFeesViewModel Map(DenominationFeesModel x)
        {
            return new DenominationFeesViewModel
            {

                Id = (int)x.Id,
                FeesId = (int)x.FeesId,
                FeesTypeId = (int)x.FeesTypeId,
                FeesTypeName = x.FeesTypeName,
                PaymentMode = x.PaymentMode,
                FeesValue = (decimal)x.FeesValue,
                PaymentModeId = (int)x.PaymentModeId,
                DenominationId = (int)x.DenominationId,
                DenominationFullName = x.DenominationFullName
            };
        }
    }
}
