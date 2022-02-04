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
    public class UsersController : Controller
    {
        private readonly IUsersApi _usersApi;
        public UsersController(IUsersApi usersApi)
        {
            _usersApi = usersApi;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? accountId = null, int page = 1)
        {
            var data = new UserModelPagedResult();
            if (!accountId.HasValue)
            {
                data = await _usersApi.ApiUsersGetAllAdminGetAsync(page, 10);
            }
            else
            {
                data = await _usersApi.ApiUsersAccountAccountIdGetAsync(accountId.ToString());
            }
            var viewModel = new PagedResult<UsersViewModel>
            {
                Results = data.Results.Select(u => Map(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = 10
            };

            ViewBag.AccountId = accountId;
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create(int? accountId)
        {
            return View(new CreateUserViewModel() { AccountID = accountId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            try
            {
                _usersApi.ApiUsersCreateUserPost(new CreateUserModel(
                    username: model.Username,
                    password: model.Password,
                    accountId: model.AccountID,
                    email: model.Email,
                    userRole: model.UserRole
                    ));

                TempData["result"] = true;
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("1", ex.Message);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _usersApi.ApiUsersManageRolesGetAsync(userId);
            var viewModel = new UserRolesViewModel
            {
                UserId = user.UserId,
                Roles = user.Roles.Select(s => new CheckBoxViewModel
                {
                    IsSelected = (bool)s.IsSelected,
                    DisplayName = s.DisplayName
                }).ToList(),
                UserName = user.UserName
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _usersApi.ApiUsersManageRolesPostAsync(new UserRolesModel(
                  userId: model.UserId,
                  roles: model.Roles.Select(r => new CheckBoxModel(displayName: r.DisplayName, isSelected: r.IsSelected)).ToList()
               ));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> ManagePermissions(string userId)
        {
            var user = await _usersApi.ApiUsersManagePermissionsGetAsync(userId);

            var viewModel = new UsersPermissionsViewModel
            {
                UserId = userId,
                UserName = user.UserName,
                UserClaims = user.UserClaims.Select(r => new CheckBoxViewModel
                {
                    DisplayName = r.DisplayName,
                    IsSelected = (bool)r.IsSelected
                }).ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagePermissions(UsersPermissionsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await _usersApi.ApiUsersManagePermissionsPostAsync(new UserPermissionsModel(
                  userId: model.UserId,
                  userClaims: model.UserClaims.Select(r => new CheckBoxModel(displayName: r.DisplayName, isSelected: r.IsSelected)).ToList()
                  ));

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<JsonResult> ResetPassword(string id)
        {
            var result = await _usersApi.ApiUsersResetPasswordUserIdPostAsync(id);
            return Json(result);
        }

        private UsersViewModel Map(UserModel model)
        {
            return new UsersViewModel
            {
                Id = model.Id,
                Email = model.Email,
                Roles = model.Roles,
                UserName = model.UserName
            };
        }
    }
}
