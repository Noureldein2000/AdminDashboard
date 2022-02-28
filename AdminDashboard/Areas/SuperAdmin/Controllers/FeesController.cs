using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Helper;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Route("SuperAdmin/[controller]/{action}/{id?}")]
    [Authorize]
    public class FeesController : Controller
    {
        private readonly IAccountApi _api;
        private readonly IFeesApi _apiFees;
        public FeesController(IAccountApi accountApi, IFeesApi feesApi)
        {
            _api = accountApi;
            _apiFees = feesApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, bool processSucceded = false)
        {
            var data = await _apiFees.ApiFeesGetFeesGetAsync(page, pageSize);

            var viewModel = new PagedResult<FeesViewModel>
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
            return View(new FeesViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FeesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!model.EndDate.HasValue)
            {
                model.EndDate = DateTime.Now.AddYears(100);
            }

            _apiFees.ApiFeesAddFeePost(MapToModel(model));
            return RedirectToAction(nameof(Index), new { processSucceded =true});
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _apiFees.ApiFeesGetFeeByIdIdGet(id);
            return View(MapEdit(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditFeesViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!model.EndDate.HasValue)
            {
                model.EndDate = DateTime.Now.AddYears(100);
            }

            _apiFees.ApiFeesEditFeePut(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            _apiFees.ApiFeesChangeStatusIdPut(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            _apiFees.ApiFeesDeleteFeeIdDelete(id);
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
        private EditFeesViewModel MapEdit(FeesModel x)
        {
            return new EditFeesViewModel
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
