using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Helper;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    [Route("SuperAdmin/[controller]/{action}/{id?}")]
    [Authorize]
    public class CommissionController : Controller
    {
        private readonly IAccountApi api;
        private readonly ICommissionApi apiCommission;
        public CommissionController(
            )
        {
            string url = "https://localhost:44303";
            string urlTms = "https://localhost:44321";
            api = new AccountApi(url);
            apiCommission = new CommissionApi(urlTms);
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
        {
            var data = await apiCommission.ApiCommissionGetCommissionsGetAsync(page, pageSize);

            var viewModel = new PagedResult<CommissionViewModel>
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
            return View(new CommissionViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommissionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            apiCommission.ApiCommissionAddCommissionPost(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = apiCommission.ApiCommissionGetCommissionByIdIdGet(id);
            return View(Map(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CommissionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            apiCommission.ApiCommissionEditCommissionPut(MapToModel(model));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            apiCommission.ApiCommissionChangeStatusIdPut(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            apiCommission.ApiCommissionDeleteCommissionIdDelete(id);
            return RedirectToAction(nameof(Index));
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
