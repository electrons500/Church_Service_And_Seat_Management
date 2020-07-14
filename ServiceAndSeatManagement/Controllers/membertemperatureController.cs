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
    public class membertemperatureController : Controller
    {
        private TemperatureService _TemperatureService;
        public membertemperatureController(TemperatureService temperatureService)
        {
            _TemperatureService = temperatureService;
        }
        // GET: membertemperature
        public ActionResult Index()
        {
            var model = _TemperatureService.GetTemperatures();
            return View(model);
        }

        // GET: membertemperature/Details/5
        public ActionResult Details(int id)
        {
            var model = _TemperatureService.GetTemperatureDetails(id);
            return View(model);

        }

        // GET: membertemperature/Create
        public ActionResult Create()
        {
            var model = _TemperatureService.CreateTemperature();
            return View(model);
        }

        // POST: membertemperature/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TemperatureViewModel model)
        {
            try
            {
                bool result = _TemperatureService.AddTemperature(model);
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

        // GET: membertemperature/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _TemperatureService.GetTemperatureDetails(id);
            return View(model);
        }

        // POST: membertemperature/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TemperatureViewModel model)
        {
            try
            {
                bool result = _TemperatureService.UpdateTemperature(model);
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

        // GET: membertemperature/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: membertemperature/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                bool result = _TemperatureService.DeleteTemperature(id);
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
    }
}
