using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceAndSeatManagement.Controllers
{
    public class StartpageController : Controller
    {
        // GET: StartpageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StartpageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StartpageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StartpageController/Create
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

        // GET: StartpageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StartpageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: StartpageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StartpageController/Delete/5
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
