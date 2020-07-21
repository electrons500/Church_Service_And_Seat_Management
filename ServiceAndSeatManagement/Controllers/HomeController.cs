using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceAndSeatManagement.Models;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;

namespace ServiceAndSeatManagement.Controllers
{
    public class HomeController : Controller
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
             var a = _Context.ServiceCategory.Where(x => x.ServiceCategoryId == 1).FirstOrDefault();
             var b = _Context.ServiceCategory.Where(x => x.ServiceCategoryId == 2).FirstOrDefault();
             var c = _Context.ServiceCategory.Where(x => x.ServiceCategoryId == 3).FirstOrDefault();

             var firstServiceCount = a.MemberCounts;
             var SecondServiceCount = b.MemberCounts;
             var ThirdServiceCount = c.MemberCounts;

            ViewBag.FirstService = firstServiceCount;
            ViewBag.SecondService = SecondServiceCount;
            ViewBag.ThirdService = ThirdServiceCount;
            
            
            return View();
        }

        public IActionResult Privacy()
        {
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
