using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceAndSeatManagement.Models;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using static ServiceAndSeatManagement.Models.Enum;

namespace ServiceAndSeatManagement.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private ServiceDBContext _Context;
   

        public HomeController(ILogger<HomeController> logger,ServiceDBContext context)
        {
            _logger = logger;
            _Context = context;
        }

        public IActionResult Index()
        {
            //count number of members and department and assign it to the variables
            var Registered_Members_Count = _Context.Members.Count();
            var DepartmentCount = _Context.Department.Count();
            var currentDate = DateTime.Now;

            var temperatureChecked = _Context.Temperature.Where(x => x.CurrentDate == currentDate).Count();
            //assign the integer in the variables to the viewbags
            ViewBag.RegMembersCount = Registered_Members_Count;
            ViewBag.departmentCount = DepartmentCount;
            ViewBag.temperatureCount = temperatureChecked;
            
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Settings()
        {
            return View();
        }

       

    }
}
