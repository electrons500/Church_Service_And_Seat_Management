using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAndSeatManagement.Models.Services;

namespace ServiceAndSeatManagement.Controllers
{
    public class DailyreportController : Controller
    {
        private DailyReportService _DailyReportService;
        public DailyreportController(DailyReportService dailyReportService)
        {
            _DailyReportService = dailyReportService;
        }
        // GET: Dailyreport
        public ActionResult Index()
        {
            var model = _DailyReportService.GetDailyReport();
            return View(model);
        }

        // GET: Dailyreport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dailyreport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dailyreport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Dailyreport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dailyreport/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Dailyreport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dailyreport/Delete/5
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