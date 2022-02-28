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
    public class TaxController : Controller
    {
        private readonly IAccountApi _api;
        private readonly ITaxApi _apiTaxes;
        public TaxController(IAccountApi accountApi, ITaxApi apiTaxes)
        {
            _api = accountApi;
            _apiTaxes = apiTaxes;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, bool processSucceded = false)
        {
            var data = await _apiTaxes.ApiTaxGetTaxesGetAsync(page, pageSize);

            var viewModel = new PagedResult<TaxesViewModel>
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
            return View(new TaxesViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaxesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!model.EndDate.HasValue)
            {
                model.EndDate = DateTime.Now.AddYears(100);
            }

            _apiTaxes.ApiTaxAddTaxPost(MapToModel(model));
            return RedirectToAction(nameof(Index), new { processSucceded = true });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _apiTaxes.ApiTaxGetTaxByIdIdGet(id);
            return View(MapEdit(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditTaxesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!model.EndDate.HasValue)
            {
                model.EndDate = DateTime.Now.AddYears(100);
            }

            _apiTaxes.ApiTaxEditTaxPut(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            _apiTaxes.ApiTaxChangeStatusIdPut(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            _apiTaxes.ApiTaxDeleteTaxIdDelete(id);
            return Json(id);
        }

        private TaxesViewModel Map(TaxModel x)
        {
            return new TaxesViewModel
            {
                ID = (int)x.Id,
                TaxesTypeID = (TaxType)x.TaxesTypeID,
                AmountFrom = (decimal)x.AmountFrom,
                AmountTo = (decimal)x.AmountTo,
                CreatedBy = (int)x.CreatedBy,
                TaxesTypeName = x.TaxesTypeName,
                PaymentModeName = x.PaymentModeName,
                PaymentModeID = (PaymentMode)x.PaymentModeID,
                Status = (bool)x.Status,
                Value = (decimal)x.Value,
                StartDate = (DateTime)x.StartDate,
                EndDate = (DateTime)x.EndDate
            };
        }
        private EditTaxesViewModel MapEdit(TaxModel x)
        {
            return new EditTaxesViewModel
            {
                ID = (int)x.Id,
                TaxesTypeID = (TaxType)x.TaxesTypeID,
                AmountFrom = (decimal)x.AmountFrom,
                AmountTo = (decimal)x.AmountTo,
                CreatedBy = (int)x.CreatedBy,
                TaxesTypeName = x.TaxesTypeName,
                PaymentModeName = x.PaymentModeName,
                PaymentModeID = (PaymentMode)x.PaymentModeID,
                Status = (bool)x.Status,
                Value = (decimal)x.Value,
                StartDate = (DateTime)x.StartDate,
                EndDate = (DateTime)x.EndDate
            };
        }
        

        private TaxModel MapToModel(TaxesViewModel x)
        {
            return new TaxModel
            {
                Id = (int)x.ID,
                TaxesTypeID = ((int)x.TaxesTypeID),
                AmountFrom = (double)x.AmountFrom,
                AmountTo = (double)x.AmountTo,
                CreatedBy = (int)x.CreatedBy,
                TaxesTypeName = x.TaxesTypeName,
                PaymentModeName = x.PaymentModeName,
                PaymentModeID = (int)x.PaymentModeID,
                Status = x.Status,
                Value = (double)x.Value,
                StartDate = x.StartDate,
                EndDate = x.EndDate
            };
        }
    }
}
