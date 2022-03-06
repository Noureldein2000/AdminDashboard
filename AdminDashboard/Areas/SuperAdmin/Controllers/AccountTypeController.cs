using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class AccountTypeController : Controller
    {
        private readonly IAdminServiceApi _adminServiceApi;
        private readonly IAccountTypeApi _accountTypeServiceApi;
        public AccountTypeController(IAdminServiceApi adminServiceApi, IAccountTypeApi accountTypeApi)
        {
            _accountTypeServiceApi = accountTypeApi;
            _adminServiceApi = adminServiceApi;
        }
        public async Task<IActionResult> Index(int page = 1, int size = 10, string language = "ar", bool processSucceded = false)
        {
            var model = await _accountTypeServiceApi.ApiAccountTypeGetAccountTypesGetAsync(page, size, language);

            var viewModel = new PagedResult<AccountTypeViewModel>
            {
                Results = model.Results.Select(u => MapToViewModel(u)).ToList(),
                PageCount = (int)model.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            ViewBag.processSucceded = processSucceded;
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new AccountTypeViewModel());
        }

        [HttpPost]
        public IActionResult Create(AccountTypeViewModel model)
        {
            try
            {
                //throw new Exception("There is some thing error happened");
                var result = _accountTypeServiceApi.ApiAccountTypeAddAccountTypePost(new AccountTypeModel
                      (
                      name: model.Name,
                      nameAr: model.NameAr,
                      status: model.Status
                      ));

                return Json(MapToViewModel(result));
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message.Remove(0, ex.Message.IndexOf('{'));
                return Json(JsonConvert.DeserializeObject<ExceptionErrorMessage>(errorMessage));
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _accountTypeServiceApi.ApiAccountTypeGetAccountTypeByIdIdGet(id);
            return View(MapToViewModel(model));
        }

        [HttpPost]
        public IActionResult Edit(AccountTypeViewModel model)
        {
            try
            {
                _accountTypeServiceApi.ApiAccountTypeEditAccountTypePut(new AccountTypeModel
                    (
                    id: model.Id,
                    name: model.Name,
                    nameAr: model.NameAr,
                    status: model.Status,
                    treeLevel: model.TreeLevel
                    ));

                return Json(model);
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
            _accountTypeServiceApi.ApiAccountTypeDeleteAccountTypeIdDelete(id);
            return Json(id);
        }

        [HttpGet]
        public ActionResult ChangeStatus(int id)
        {
            _accountTypeServiceApi.ApiAccountTypeChangeStatusIdPut(id);
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
