using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.Services;
using System;
using System.IO;
using System.Linq;

namespace ServiceAndSeatManagement.Controllers
{
    public class DailytemperatureRecordsController : Controller
    {
        private ServiceDBContext _Context;
        private DailytemperatureRecordsService _DailytemperatureRecordsService;
        
        public DailytemperatureRecordsController( ServiceDBContext context,DailytemperatureRecordsService dailytemperatureRecordsService)
        {
            _Context = context;
            _DailytemperatureRecordsService = dailytemperatureRecordsService;
           
        }
        public IActionResult Index()
        {
            string currentdate = DateTime.Now.ToShortDateString();

            var CountTemp = _Context.Temperature
                                                  .Where(x => x.CurrentDate == Convert.ToDateTime(currentdate))
                                                  .Count();
            ViewBag.MemberTemperature = CountTemp;                                  

            var model = _DailytemperatureRecordsService.GetDailyTemperatureRecords();
            
            return View(model);
        }


        public ActionResult Export_To_Excel()
        {
            var temperature = _DailytemperatureRecordsService.GetDailyTemperatureRecords();
            
            var SNumber = 1;

            using (var workbook = new XLWorkbook())
            {
               
                var worksheet = workbook.Worksheets.Add("temperature");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value = "S/No";
                worksheet.Cell(currentRow, 2).Value = "Name";
                worksheet.Cell(currentRow, 3).Value = "Gender";
                worksheet.Cell(currentRow, 4).Value = "Temperature";
                worksheet.Range("A1:D1").Style.Font.SetBold();
                worksheet.Range("A1:D1").Style.Font.FontSize = 12;
                worksheet.Range("A1:D1").Style.Fill.BackgroundColor = XLColor.AshGrey;


                //body
                foreach (var item in temperature)
                {
                   
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = SNumber;
                    worksheet.Cell(currentRow, 2).Value = item.MemberName;
                    if(item.GenderId == 1)
                    {
                        worksheet.Cell(currentRow, 3).Value = "MALE";
                    }
                    else
                    {
                        worksheet.Cell(currentRow, 3).Value ="FEMALE";
                    }
                    worksheet.Cell(currentRow, 4).Value = item.Temperature;

                    SNumber++;
                }
                //body

                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File( 
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "reports.xlsx"
                        
                        );
                }

            }
        }

    }
}
