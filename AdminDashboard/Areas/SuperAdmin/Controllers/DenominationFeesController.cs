using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Index(int denominationId, string denominationName, bool processSucceded = false)
        {
            var data = await _apiDenominationFees.ApiDenominationFeesGetdenominationFeesByDenominationIdDenominationIdGetAsync(denominationId);

            var fees = _apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = $"From: {a.AmountFrom} To: {a.AmountTo}, Value: {a.Value} {a.PaymentModeName}",
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.denominationId = denominationId;
            ViewBag.Fees = fees;
            ViewBag.DenominationName = denominationName;
            ViewBag.processSucceded = processSucceded;
            return View(data.Select(x => Map(x)));
        }

        [HttpGet]
        public IActionResult Create(int id, string denominationName)
        {
            var fees = _apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = $"From: {a.AmountFrom} To: {a.AmountTo}, Value: {a.Value} {a.PaymentModeName}",
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateDenominationFeesViewModel
            {
                DenominationId = id,
                DenominationName = denominationName,
                Fees = fees,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateDenominationFeesViewModel model)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    var fees = _apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
                //    {
                //        Text = $"From: {a.AmountFrom} To: {a.AmountTo}, Value: {a.Value} {a.PaymentModeName}",
                //        Value = a.Id.ToString()
                //    }).ToList();

                //    model.Fees = fees;

                //    return View(model);
                //}

                var result = _apiDenominationFees.ApiDenominationFeesAddDenominationFeesPost(new AddDenominationFeesModel(
                     denominationId: model.DenominationId,
                     feesId: model.FeesId));

                return Json(Map(result));
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message.Remove(0, ex.Message.IndexOf('{'));
                return Json(JsonConvert.DeserializeObject<ExceptionErrorMessage>(errorMessage));
            }
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                _apiDenominationFees.ApiDenominationFeesDeleteDenominationFeeIdDelete(id: id);
                return Json(id);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
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
                AmountFrom = (decimal)x.AmountFrom,
                AmountTo = (decimal)x.AmountTo
            };
        }
    }
}
