using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.Services;
using ServiceAndSeatManagement.Models.ViewModel;
using static ServiceAndSeatManagement.Models.Enum;

namespace ServiceAndSeatManagement.Controllers
{
    public class membertemperatureController : BaseController
    {
        private TemperatureService _TemperatureService;
        private ServiceDBContext _Context;
        public membertemperatureController(TemperatureService temperatureService,ServiceDBContext context)
        {
            _TemperatureService = temperatureService;
            _Context = context;
        }
        // GET: membertemperature
        public ActionResult Index()
        {
           
            return View();
        }

        // GET: membertemperature/Details/5
        public ActionResult Details(int id)
        {
            var model = _TemperatureService.GetTemperatureDetails(id);
            return View(model);

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
                    Alert("Congratulations","Temperature successfully updated!", NotificationType.success);
                }
                else
                {
                    Alert("Error","Temperature Failed to be updated!", NotificationType.error);
                }

                return View(nameof(Index));
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _TemperatureService.GetTemperatureDetails(id);

            return View(model);
        }

        // POST: Members/Delete/5
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

        [HttpGet]

        public ActionResult GetTemperature()
        {
            var model = _TemperatureService.GetTemperatures();
            return Json(new { data = model });
        }

        [HttpDelete]

        // DELETE: membertemperature/DeleteAllDataApiJson/id
        public async Task<IActionResult> DeleteAllDataApiJson(int id)
        {
            var temperatureId = await _Context.Temperature.FindAsync(id);
            if (temperatureId == null)
            {
                return Json(new { success = false, message = "Data not found" });
            }
            else
            {

                _Context.Temperature.Remove(temperatureId);
                await _Context.SaveChangesAsync();

                return Json(new { success = true, message = "Member temperature successfully deleted!" });
            }
        }
    }
}
