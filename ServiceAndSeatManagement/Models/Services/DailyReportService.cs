using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.Services
{
    public class DailyReportService
    {
        private ServiceDBContext _Context;
        private WeekServices _WeekServices;
        public DailyReportService(ServiceDBContext context,WeekServices weekServices)
        {
            _Context = context;
            _WeekServices = weekServices;
        }

        public DailyReportViewModel CreateDailyReport()
        {
            try
            {
                DailyReportViewModel model = new DailyReportViewModel();
                List<WeekViewModel> weeks = _WeekServices.GetWeeks();
                SelectList weekLists = new SelectList(weeks, "WeekId", "WeekName");

                model.WeekList = weekLists;

                return model;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DailyReportViewModel> GetDailyReport()
        {
            try
            {
                List<DailyReport> dailyReports = _Context.DailyReport.Include(x => x.Week).ToList();

                List<DailyReportViewModel> model = dailyReports.Select(b => new DailyReportViewModel
                {
                    ReportId = b.ReportId,
                    Service1 = b.Service1,
                    Service2 = b.Service2,
                    Service3 = b.Service3,
                    Service4 = b.Service4,
                    WeekId = b.WeekId,
                    WeekName = b.Week.WeekName

                }).ToList();


                return model;
            }
            catch (Exception)
            {

                List<DailyReportViewModel> emptymodel = new List<DailyReportViewModel>();

                return emptymodel;
            }
        }


    }
}
