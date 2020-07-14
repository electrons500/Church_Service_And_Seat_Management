using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAndSeatManagement.Models.Services;
using ServiceAndSeatManagement.Models.ViewModel;

namespace ServiceAndSeatManagement.Controllers
{
    public class ServiceCategoryController : Controller
    {
        private ServiceCategoryService _ServiceCategoryService;
        public ServiceCategoryController(ServiceCategoryService serviceCategoryService)
        {
            _ServiceCategoryService = serviceCategoryService;
        }
        
        // GET: ServiceCategory
        public ActionResult Index()
        {
            var model = _ServiceCategoryService.GetServiceCategories();
            return View(model);
        }

        // GET: ServiceCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceCategoryViewModel model)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceCategory/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _ServiceCategoryService.GetServiceCategoryDetails(id);
            return View(model);
        }

        // POST: ServiceCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceCategoryViewModel model)
        {
            try
            {
                bool result = _ServiceCategoryService.UpdateService(model);
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                }

                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceCategory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}