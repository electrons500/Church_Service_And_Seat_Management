using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAndSeatManagement.Models.Services;
using ServiceAndSeatManagement.Models.ViewModel;
using static ServiceAndSeatManagement.Models.Enum;

namespace ServiceAndSeatManagement.Controllers
{
    public class DepartmentController : BaseController
    {
        private DepartmentService _DepartmentService;
        public DepartmentController(DepartmentService departmentService)
        {
            _DepartmentService = departmentService;
        }
        // GET: Department
        public ActionResult Index()
        {
            var model = _DepartmentService.GetDepartments();
           
            return View(model);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            var model = _DepartmentService.GetDepartmentDetails(id);
            return View(model);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel model)
        {
            try
            {
                bool result = _DepartmentService.AddDepartment(model);
                if (result)
                {
                    Alert("Data successfully added!", NotificationType.success);
                }
                else
                {
                    Alert("Data Failed to be added!", NotificationType.error);
                }

                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _DepartmentService.GetDepartmentDetails(id);
            return View(model);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel model)
        {
            try
            {
                bool result = _DepartmentService.UpdateDepartment(model);
                if (result)
                {
                    Alert("Data successfully updated!", NotificationType.success);
                }
                else
                {
                    Alert("Data Failed to be updated!", NotificationType.error);
                }

                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _DepartmentService.GetDepartmentDetails(id);
            return View(model);
        }

        // POST: Department/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _DepartmentService.RemoveDepartment(id);
                if (result)
                {
                    return Json(
                         new
                         {
                             state = 0,
                             msg = "Department has been successfully deleted.",
                             redirectUrlInSuccess = "Index"
                         }
                         );
                }
                else
                {
                    return View();
                }




            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Something wrong has happened.");
                return null;
            }
        }
    }
}