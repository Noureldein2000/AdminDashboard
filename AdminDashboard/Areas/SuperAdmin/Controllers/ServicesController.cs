using AdminDashboard.Areas.SuperAdmin.Models;
using AdminDashboard.Models;
using AdminDashboard.Models.SwaggerModels;
using AdminDashboard.SwaggerClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ServicesController : Controller
    {
        private readonly IAdminServiceApi _api;
        private readonly IDenominationApi _apiDenomination;
        public ServicesController(IAdminServiceApi adminServiceApi, IDenominationApi denominationApi)
        {
            _api = adminServiceApi;
            _apiDenomination = denominationApi;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int size = 10, bool processSucceded = false)
        {
            var data = await _api.ApiAdminServiceGetServicesGetAsync(page, size);

            ViewBag.ServiceTypes = _api.ApiAdminServiceGetServiceTypesGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.processSucceded = processSucceded;
            var viewModel = new PagedResult<AdminServiceViewModel>
            {
                Results = data.Results.Select(u => Map(u)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = size
            };

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> SearchServices(int? dropDownFilter, string searchKey = null, int page = 1, int size = 10, string lang = "ar", bool processSucceded = false)
        {
            var data = await _api.ApiAdminServiceSearchServicesGetAsync(dropDownFilter, searchKey, page, size, lang);

            ViewBag.ServiceTypes = _api.ApiAdminServiceGetServiceTypesGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            ViewBag.processSucceded = processSucceded;
            var viewModel = new PagedResult<AdminServiceViewModel>
            {
                Results = data.Results.Select(x => Map(x)).ToList(),
                PageCount = (int)data.PageCount,
                CurrentPage = page,
                PageSize = size,
                DropDownFilter = dropDownFilter,
                SearchKey = searchKey
            };
            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {

            var serviceEntities = _api.ApiAdminServiceGetServiceEntitiesGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var servicesCategories = _api.ApiAdminServiceGetServicesCategoriesGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var serviceTypes = _api.ApiAdminServiceGetServiceTypesGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            AdminServiceViewModel viewModel = new AdminServiceViewModel()
            {
                ServiceEntities = serviceEntities,
                ServicesCategories = servicesCategories,
                ServiceTypes = serviceTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdminServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var serviceEntities = _api.ApiAdminServiceGetServiceEntitiesGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                var servicesCategories = _api.ApiAdminServiceGetServicesCategoriesGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                var serviceTypes = _api.ApiAdminServiceGetServiceTypesGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                model.ServiceEntities = serviceEntities;
                model.ServicesCategories = servicesCategories;
                model.ServiceTypes = serviceTypes;

                return View(model);
            }

            _api.ApiAdminServiceAddServicePost(new AddServiceModel(
                name: model.Name,
                arName: model.ArName,
                status: false,
                serviceTypeID: model.ServiceTypeID,
                code: model.Code,
                serviceEntityID: model.ServiceEntityID,
                //serviceCategoryID: model.ServiceCategoryID,
                pathClass: model.PathClass,
                classType: model.ClassType
                ));

            return RedirectToAction(nameof(Index), new { processSucceded = true });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _api.ApiAdminServiceGetServiceByIdIdGet(id);

            var serviceEntities = _api.ApiAdminServiceGetServiceEntitiesGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var servicesCategories = _api.ApiAdminServiceGetServicesCategoriesGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var serviceTypes = _api.ApiAdminServiceGetServiceTypesGet().Select(a => new SelectListItem
            {
                Text = a.Name,
                Value = a.Id.ToString()
            }).ToList();

            var viewModel = Map(data);
            viewModel.ServiceEntities = serviceEntities;
            viewModel.ServicesCategories = servicesCategories;
            viewModel.ServiceTypes = serviceTypes;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AdminServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var serviceEntities = _api.ApiAdminServiceGetServiceEntitiesGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                var servicesCategories = _api.ApiAdminServiceGetServicesCategoriesGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                var serviceTypes = _api.ApiAdminServiceGetServiceTypesGet().Select(a => new SelectListItem
                {
                    Text = a.Name,
                    Value = a.Id.ToString()
                }).ToList();

                model.ServiceEntities = serviceEntities;
                model.ServicesCategories = servicesCategories;
                model.ServiceTypes = serviceTypes;

                return View(model);
            }

            _api.ApiAdminServiceEditServicePut(new EditServiceModel(
                id: model.Id,
                name: model.Name,
                arName: model.ArName,
                status: model.Status,
                serviceTypeID: model.ServiceTypeID,
                code: model.Code,
                serviceEntityID: model.ServiceEntityID,
                //serviceCategoryID: model.ServiceCategoryID,
                pathClass: model.PathClass,
                classType: model.ClassType
                ));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ChangeStatus(int id)
        {
            _api.ApiAdminServiceChangeStatusPut(id);
            return RedirectToAction(nameof(Index));
        }
        private AdminServiceViewModel Map(AdminServiceModel model)
        {
            return new AdminServiceViewModel
            {
                Id = model.Id,
                Name = model.Name,
                ArName = model.ArName,
                ServiceTypeID = model.ServiceTypeID,
                ServiceTypeName = model.ServiceTypeName,
                //ServiceCategoryID = model.ServiceCategoryID,
                ServiceCategoryName = model.ServiceCategoryName,
                Status = (bool)model.Status,
                Code = model.Code,
                ServiceEntityID = model.ServiceEntityID,
                ServiceEntityName = model.ServiceEntityName,
                CreationDate = model.CreationDate,
                ClassType = model.ClassType
            };
        }

    }
}
