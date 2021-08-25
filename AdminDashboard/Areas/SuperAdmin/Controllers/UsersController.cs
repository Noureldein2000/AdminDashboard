using AdminDashboard.Areas.SuperAdmin.Models;
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
    public class UsersController : Controller
    {
        private readonly IUsersApi _usersApi;
        public UsersController(
            //IUsersApi usersApi
            )
        {
            string url = "https://localhost:44303/";
            _usersApi = new UsersApi(url);
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
            return View(viewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateUserViewModel
            {

            };
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = _usersApi.ApiUsersManageRolesGet(userId);
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
            _usersApi.ApiUsersManageRolesPost(new UserRolesModel(
                userId: model.UserId,
                roles: model.Roles.Select(r => new CheckBoxModel(displayName: r.DisplayName, isSelected: r.IsSelected)).ToList()
             ));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> ManagePermissions(string userId)
        {
            var user = _usersApi.ApiUsersManagePermissionsGet(userId);

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
            _usersApi.ApiUsersManagePermissionsPost(new UserPermissionsModel(
                userId: model.UserId,
                userClaims: model.UserClaims.Select(r => new CheckBoxModel(displayName: r.DisplayName, isSelected: r.IsSelected)).ToList()
                ));
            return RedirectToAction(nameof(Index));
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
