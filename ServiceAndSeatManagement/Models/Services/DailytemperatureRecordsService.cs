using Microsoft.EntityFrameworkCore;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.Services
{
    public class DailytemperatureRecordsService
    {
        private ServiceDBContext _Context;
        private TemperatureService _TemperatureService;
        public DailytemperatureRecordsService(ServiceDBContext context,TemperatureService temperatureService)
        {
            _Context = context;
            _TemperatureService = temperatureService;
        }


        public List<DailyTemperatureRecordsViewModel> GetDailyTemperatureRecords()
        {
            try
            {
                string currentdate = DateTime.Now.ToShortDateString();

                var temperature = _Context.Temperature  
                                                      .Include(x => x.Member)
                                                      .Include(x => x.Member.Gender)
                                                      .Where(x => x.CurrentDate == Convert.ToDateTime(currentdate) )
                                                      .ToList();
                List<DailyTemperatureRecordsViewModel> model = temperature.Select(x => new DailyTemperatureRecordsViewModel
                {
                    MemberId = x.MemberId,
                    MemberName = x.Member.FullName,
                    GenderId = x.Member.GenderId,
                    GenderName = x.Member.Gender.GenderName,
                    Temperature = x.TempuratureNumber
                }).ToList();


                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }

   
}
