using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
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
        public ActionResult Index(string searchString,string sortOrder,int pageNumber=1,int pageSize=5)
        {
            ViewBag.TempSortOrderParam = String.IsNullOrEmpty(sortOrder) ? "Temp_desc" : "";
            string currentdates = DateTime.Now.ToString("yyyy'-'MM'-'dd");

            int ExcludeRecords = (pageNumber * pageSize) - pageSize;
            var temperatures = from b in _Context.Temperature
                                                .Include(x => x.Member)
                                                .Include(x => x.ServiceCategory)
                                                .Include(x => x.Verify)
                                                
                               select b;

            //counts number of temperature record
            var RowsCounted = temperatures.Count();
            var tempCount = RowsCounted;
            //*********This logic is a switch statement converted into expressions********
            //sorting
            temperatures = sortOrder switch
            {
                "Temp_desc" => temperatures.OrderByDescending(b => b.TempuratureNumber),
                _ => temperatures.OrderBy(b => b.TempuratureNumber),
            };

            //*******************************************************************

           
            temperatures = temperatures
                                  .Where(x => x.CurrentDate == Convert.ToDateTime(currentdates))
                                 .Skip(ExcludeRecords)
                                 .Take(pageSize);

            //code for filtering
            if (!String.IsNullOrEmpty(searchString))
            {
                // members = members.Where(x => x.FullName.Contains(searchString));
                // memberCount = members.Count();
                temperatures = temperatures.Where(x => x.Member.FullName.Contains(searchString));
                RowsCounted = 0;

            }



            if (temperatures.Count() == 0 || temperatures.Count() < 5)
            {
                RowsCounted = 0;
            }
            else
            {
               //Each row is 5 in one page.If we have 12 rows it means 2 pages is suppose to show but it shows pagination count to 3 pages.so
               //to make it up I substract one page which is 5 unknown row to correct the error
                RowsCounted = tempCount - 5;
            }

          
            var result = new PagedResult<Temperature>
            {
                Data = temperatures.AsNoTracking().ToList(),
                TotalItems = RowsCounted,
                PageNumber = pageNumber,
                PageSize = pageSize 

            };
            return View(result);
        }

        // GET: membertemperature/Details/5
        public ActionResult Details(int id)
        {
            var model = _TemperatureService.GetTemperatureDetails(id);
            return View(model);

        }

        // GET: membertemperature/Create
        public ActionResult Create(int id)
        {
            ViewBag.MemberId = id;

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
                if(result)
                {
                    Alert("Temperature successfully recorded!", NotificationType.success);


                }
                else
                {
                    Alert("Temperature Failed to be recorded!", NotificationType.error);
                }

                return View();
            }
            catch (Exception)
            {

                throw;

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
                    Alert("Temperature successfully updated!", NotificationType.success);
                }
                else
                {
                    Alert("Temperature Failed to be updated!", NotificationType.error);
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
