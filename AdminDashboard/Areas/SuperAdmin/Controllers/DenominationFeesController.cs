using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
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
    public class DenominationFeesController : Controller
    {
        private readonly IFeesApi apiFees;
        private readonly IDenominationFeesApi apiDenominationFees;
        private readonly IDenominationApi apiDenomination;
        public DenominationFeesController(
            )
        {
            //string url = "https://localhost:44303";
            string urlTms = "https://localhost:44321";
            apiFees = new FeesApi(urlTms);
            apiDenominationFees = new DenominationFeesApi(urlTms);
            apiDenomination = new DenominationApi(urlTms);
        }
        [HttpGet]
        public async Task<IActionResult> Index(int denominationId)
        {
            var data = await apiDenominationFees.ApiDenominationFeesGetdenominationFeesByDenominationIdDenominationIdGetAsync(denominationId);
            return View(data.Select(x => Map(x)));
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var fees = apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
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
            if (!ModelState.IsValid)
            {
                var fees = apiFees.ApiFeesGetFeesGet(1, 100).Results.Select(a => new SelectListItem
                {
                    Text = a.Value.ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                model.Fees = fees;

                return View(model);
            }

            apiDenominationFees.ApiDenominationFeesAddDenominationFeesPost(new AddDenominationFeesModel(
                denominationId: model.DenominationId,
                feesId: model.FeesId));

            return RedirectToAction(nameof(Index), new { denominationId = model.DenominationId });
        }

        [HttpGet]
        public IActionResult Delete(int id, int denominationId)
        {
            apiDenominationFees.ApiDenominationFeesDeleteDenominationFeeIdDelete(id: id);

            return RedirectToAction(nameof(Index), new { denominationId = denominationId });
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
