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
    public class DenominationCommissionController : Controller
    {
        private readonly ICommissionApi apiCommissions;
        private readonly IDenominationCommissionApi apiDenominationCommission;
        public DenominationCommissionController(
            )
        {
            //string url = "https://localhost:44303";
            string urlTms = "https://localhost:44321";
            apiCommissions = new CommissionApi(urlTms);
            apiDenominationCommission = new DenominationCommissionApi(urlTms);
        }
        [HttpGet]
        public async Task<IActionResult> Index(int denominationId)
        {
            var data = await apiDenominationCommission.ApiDenominationCommissionGetdenominationCommissionByDenominationIdDenominationIdGetAsync(denominationId);
            return View(data.Select(x => Map(x)));
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var commissions = apiCommissions.ApiCommissionGetCommissionsGet(1, 100).Results.Select(a => new SelectListItem
            {
                Text = a.CommissionRange.ToString(),
                Value = a.Id.ToString()
            }).ToList();

            var model = new CreateDenominationCommissionViewModel
            {
                DenominationId = id,
                Commissions = commissions,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateDenominationCommissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var commissions = apiCommissions.ApiCommissionGetCommissionsGet(1, 100).Results.Select(a => new SelectListItem
                {
                    Text = a.CommissionRange.ToString(),
                    Value = a.Id.ToString()
                }).ToList();

                model.Commissions = commissions;

                return View(model);
            }

            apiDenominationCommission.ApiDenominationCommissionAddDenominationCommissionPost(new AddDenominationCommissionModel(
                denominationId: model.DenominationId,
                commissionId: model.CommissionId));

            return RedirectToAction(nameof(Index), new { denominationId = model.DenominationId });
        }

        [HttpGet]
        public IActionResult Delete(int id, int denominationId)
        {
            apiDenominationCommission.ApiDenominationCommissionDeleteDenominationCommissionIdDelete(id: id);

            return RedirectToAction(nameof(Index), new { denominationId = denominationId });
        }

        private DenominationCommissionViewModel Map(DenominationCommissionModel x)
        {
            return new DenominationCommissionViewModel
            {

                Id = (int)x.Id,
                CommissionId = (int)x.CommissionId,
                CommissionTypeId = (int)x.CommissionTypeId,
                CommissionTypeName = x.CommissionTypeName,
                PaymentMode = x.PaymentMode,
                CommissionValue = x.CommissionValue,
                PaymentModeId = (int)x.PaymentModeId,
                DenominationId = (int)x.DenominationId,
                DenominationFullName = x.DenominationFullName
            };
        }
    }
}
