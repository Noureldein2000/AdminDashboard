using AdminDashboard.Areas.SuperAdmin.Models;
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
    public class RolesController : Controller
    {
        private readonly IRolesApi _rolesApi;
        public RolesController(IRolesApi rolesApi)
        {
            _rolesApi = rolesApi;
        }
        public async Task<IActionResult> Index()
        {
            var roles = _rolesApi.ApiRolesGetAllGet();
            return View(roles);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Add(RoleViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //        return View("Index", await _roleManager.Roles.ToListAsync());

        //    return RedirectToAction(nameof(Index));

        //}

        [HttpGet]
        public async Task<IActionResult> ManagePermissions(string roleId)
        {
            var role = _rolesApi.ApiRolesManagePermissionsGet(roleId);

            var viewModel = new RolesPermissionsViewModel
            {
                RoleId = roleId,
                RoleName = role.RoleName,
                RoleClaims = role.RoleClaims.Select(r => new CheckBoxViewModel
                {
                    DisplayName = r.DisplayName,
                    IsSelected = (bool)r.IsSelected
                }).ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManagePermissions(RolesPermissionsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _rolesApi.ApiRolesManagePermissionsPost(new RolePermissionsModel(
                roleId: model.RoleId,
                roleClaims: model.RoleClaims.Select(r => new CheckBoxModel(displayName: r.DisplayName, isSelected: r.IsSelected)).ToList()
                ));
            return RedirectToAction(nameof(Index));
        }
    }
}
