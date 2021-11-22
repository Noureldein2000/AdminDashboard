using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class AccountTypeController : Controller
    {
        private readonly IAdminServiceApi adminServiceApi;
        private readonly IAccountTypeApi accountTypeServiceApi;
        private readonly IConfiguration _configuration;
        public AccountTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
            string url = _configuration.GetValue<string>("Urls:Authority");
            string urlTms = _configuration.GetValue<string>("Urls:TMS");
            accountTypeServiceApi = new AccountTypeApi(url);
            adminServiceApi = new AdminServiceApi(urlTms);
        }
        public async Task<IActionResult> Index(int page = 1, int size = 10, string language = "ar")
        {
            var model = await accountTypeServiceApi.ApiAccountTypeGetAccountTypesGetAsync(page, size, language);

            var viewModel = new PagedResult<AccountTypeViewModel>
            {
                Results = model.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)model.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new AccountTypeViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AccountTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                throw new Exception("There is some thing error happened");
                accountTypeServiceApi.ApiAccountTypeAddAccountTypePost(new AccountTypeModel
                    (
                    name: model.Name,
                    nameAr: model.NameAr,
                    status: model.Status
                    ));

                TempData["result"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["result"] = false;

                return View("../../Views/Shared/Error", new ErrorViewModel());
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = accountTypeServiceApi.ApiAccountTypeGetAccountTypeByIdIdGet(id);
            return View(MapToViewModel(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AccountTypeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                accountTypeServiceApi.ApiAccountTypeEditAccountTypePut(new AccountTypeModel
                    (
                    id: model.Id,
                    name: model.Name,
                    nameAr: model.NameAr,
                    status: model.Status,
                    treeLevel: model.TreeLevel
                    ));

                TempData["result"] = true;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["result"] = false;

                return View(model);
            }
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            accountTypeServiceApi.ApiAccountTypeDeleteAccountTypeIdDelete(id);
            return Json(id);
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            accountTypeServiceApi.ApiAccountTypeChangeStatusIdPut(id);
            return RedirectToAction(nameof(Index));
        }

        private AccountTypeViewModel MapToViewModel(AccountTypeModel model)
        {
            return new AccountTypeViewModel
            {
                Id = (int)model.Id,
                Name = model.Name,
                NameAr = model.NameAr,
                Status = (bool)model.Status,
                TreeLevel = model.TreeLevel
            };
        }
    }
}
