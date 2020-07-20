using cloudscribe.Pagination.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.Services;
using System;
using System.Linq;

namespace ServiceAndSeatManagement.Controllers
{
    public class DailyreportController : Controller
    {
        private DailyReportService _DailyReportService;
        private ServiceDBContext _Context;
        public DailyreportController(DailyReportService dailyReportService,ServiceDBContext context)
        {
            _DailyReportService = dailyReportService;
            _Context = context;
        }
        // GET: Dailyreport
        public ActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            int ExcludeRecords = (pageNumber * pageSize) - pageSize;
            string currentdates = DateTime.Now.ToShortDateString();

            var reports = from b in _Context.DailyReport.Include(x => x.Week)
                        select b;

            var countRecords = reports.Count();
                        
                     reports = reports
                                    .Where(x => x.CurrentDate == Convert.ToDateTime(currentdates))
                                    .Skip(ExcludeRecords)
                                    .Take(pageSize);

            var result = new PagedResult<DailyReport>
            {
                Data = reports.AsNoTracking().ToList(),
                TotalItems = countRecords,
                PageNumber = pageNumber,
                PageSize = pageSize

            };
            return View(result);
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