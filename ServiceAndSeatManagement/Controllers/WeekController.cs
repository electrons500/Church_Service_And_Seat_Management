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
    public class WeekController : BaseController
    {
        private WeekServices _WeekService;
        public WeekController(WeekServices weekService)
        {
            _WeekService = weekService;
        }
        // GET: WeekController
        public ActionResult Index()
        {
            var model = _WeekService.GetWeeks();
            return View(model);
        }

        // GET: WeekController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeekController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeekController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WeekController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _WeekService.GetWeekDetails(id);
            return View(model);
        }

        // POST: WeekController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WeekViewModel model)
        {
            try
            {
                bool result = _WeekService.UpdateWeeks(model);
                if (result)
                {
                    Alert("Week successfully changed!", NotificationType.success);
                }
                else
                {
                    Alert("Week Failed to change!", NotificationType.error);
                }
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: WeekController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeekController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
