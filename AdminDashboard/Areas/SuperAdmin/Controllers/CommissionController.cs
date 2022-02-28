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
    public class CommissionController : Controller
    {
        private readonly IAccountApi _api;
        private readonly ICommissionApi _apiCommission;
        public CommissionController(IAccountApi accountApi, ICommissionApi commissionApi)
        {
            _api = accountApi;
            _apiCommission = commissionApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10, bool processSucceded = false)
        {
            var data = await _apiCommission.ApiCommissionGetCommissionsGetAsync(page, pageSize);

            var viewModel = new PagedResult<CommissionViewModel>
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
            return View(new CommissionViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommissionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!model.EndDate.HasValue)
            {
                model.EndDate = DateTime.Now.AddYears(100);
            }
            _apiCommission.ApiCommissionAddCommissionPost(MapToModel(model));
            return RedirectToAction(nameof(Index), new { processSucceded = true });
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _apiCommission.ApiCommissionGetCommissionByIdIdGet(id);
            return View(MapEdit(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditCommissionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!model.EndDate.HasValue)
            {
                model.EndDate = DateTime.Now.AddYears(100);
            }

            _apiCommission.ApiCommissionEditCommissionPut(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            _apiCommission.ApiCommissionChangeStatusIdPut(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public JsonResult Delete(int id)
        {
            _apiCommission.ApiCommissionDeleteCommissionIdDelete(id);
            return Json(id);
        }

        private CommissionViewModel Map(CommissionModel x)
        {
            return new CommissionViewModel
            {
                ID = (int)x.Id,
                CommissionTypeID = (CommissionType)x.CommissionTypeID,
                AmountFrom = (decimal)x.AmountFrom,
                AmountTo = (decimal)x.AmountTo,
                CreatedBy = (int)x.CreatedBy,
                CommissionTypeName = x.CommissionTypeName,
                PaymentModeName = x.PaymentModeName,
                PaymentModeID = (PaymentMode)x.PaymentModeID,
                Status = (bool)x.Status,
                Value = (decimal)x.Value,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
            };
        }
        private EditCommissionViewModel MapEdit(CommissionModel x)
        {
            return new EditCommissionViewModel
            {
                ID = (int)x.Id,
                CommissionTypeID = (CommissionType)x.CommissionTypeID,
                AmountFrom = (decimal)x.AmountFrom,
                AmountTo = (decimal)x.AmountTo,
                CreatedBy = (int)x.CreatedBy,
                CommissionTypeName = x.CommissionTypeName,
                PaymentModeName = x.PaymentModeName,
                PaymentModeID = (PaymentMode)x.PaymentModeID,
                Status = (bool)x.Status,
                Value = (decimal)x.Value,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
            };
        }

        private CommissionModel MapToModel(CommissionViewModel x)
        {
            return new CommissionModel
            {
                Id = (int)x.ID,
                CommissionTypeID = ((int)x.CommissionTypeID),
                AmountFrom = (double)x.AmountFrom,
                AmountTo = (double)x.AmountTo,
                CreatedBy = (int)x.CreatedBy,
                CommissionTypeName = x.CommissionTypeName,
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
