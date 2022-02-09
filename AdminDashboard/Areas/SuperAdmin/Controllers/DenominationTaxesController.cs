using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Route("SuperAdmin/[controller]/{action}/{id?}")]
    [Authorize]
    public class DenominationTaxesController : Controller
    {
        private readonly ITaxApi _apiTaxes;
        private readonly IDenominationTaxesApi _apiDenominationTaxes;
        private readonly IDenominationApi _apiDenomination;
        public DenominationTaxesController(ITaxApi apiTaxes, IDenominationTaxesApi denominationTaxes, IDenominationApi denominationApi)
        {
            _apiTaxes = apiTaxes;
            _apiDenominationTaxes = denominationTaxes;
            _apiDenomination = denominationApi;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int denominationId, string denominationName)
        {
            var data = await _apiDenominationTaxes.ApiDenominationTaxesGetdenominationTaxesByDenominationIdDenominationIdGetAsync(denominationId);
            ViewBag.denominationId = denominationId;
            ViewBag.DenominationName = denominationName;
            return View(data.Select(x => Map(x)));
        }

        [HttpGet]
        public IActionResult Create(int id, string denominationName)
        {
            var fees = _apiTaxes.ApiTaxGetTaxesGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = a.TaxRange.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateDenominationTaxesViewModel
            {
                DenominationId = id,
                DenominationName = denominationName,
                Taxes = fees,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateDenominationTaxesViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var fees = _apiTaxes.ApiTaxGetTaxesGet(1, 100).Results.Select(a => new SelectListItem
                    {
                        Text = a.TaxRange.ToString(),
                        Value = a.Id.ToString()
                    }).ToList();

                    model.Taxes = fees;

                    return View(model);
                }

                _apiDenominationTaxes.ApiDenominationTaxesAddDenominationTaxesPost(new AddDenominationTaxesModel(
                    denominationId: model.DenominationId,
                    taxId: model.TaxesId));

                return RedirectToAction(nameof(Index), new { denominationId = model.DenominationId, denominationName = model.DenominationName });
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
            _apiDenominationTaxes.ApiDenominationTaxesDeleteDenominationTaxIdDelete(id: id);

            return Json(id);
        }

        private DenominationTaxesViewModel Map(DenominationTaxesModel x)
        {
            return new DenominationTaxesViewModel
            {

                Id = (int)x.Id,
                TaxId = (int)x.TaxId,
                TaxTypeId = (int)x.TaxTypeId,
                TaxTypeName = x.TaxTypeName,
                PaymentMode = x.PaymentMode,
                TaxValue = (decimal)x.TaxValue,
                PaymentModeId = (int)x.PaymentModeId,
                DenominationId = (int)x.DenominationId,
                DenominationFullName = x.DenominationFullName
            };
        }
    }
}
