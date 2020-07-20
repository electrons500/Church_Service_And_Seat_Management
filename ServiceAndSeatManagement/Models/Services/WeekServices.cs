using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.Services
{
    public class WeekServices
    {
        private ServiceDBContext _Context;

        public WeekServices(ServiceDBContext context)
        {
            _Context = context;
        }

        public List<WeekViewModel> GetWeeks()
        {
            try
            {
                var weeks = _Context.Week.ToList();

                List<WeekViewModel> model = weeks.Select(x => new WeekViewModel
                {
                    WeekId = x.WeekId,
                    WeekName = x.WeekName
                }).ToList();

                return model;
            }
            catch (Exception)
            {
                List<WeekViewModel> emptymodel = new List<WeekViewModel>();

                return emptymodel;
                
            }
        }

        public WeekViewModel GetWeekDetails(int? id)
        {
            try
            {
                Week weeks = _Context.Week.Where(x => x.WeekId == id).FirstOrDefault();
                WeekViewModel model = new WeekViewModel
                {
                    WeekId = weeks.WeekId,
                    WeekName = weeks.WeekName
                };

                return model;
            }
            catch (Exception)
            {
                WeekViewModel emptymodel = new WeekViewModel();

                return emptymodel;

            }
        }


        public bool AddWeeks(WeekViewModel model)
        {
            try
            {
                Week weeks = new Week
                {
                    WeekId = model.WeekId,
                    WeekName = model.WeekName
                };

                _Context.Week.Add(weeks);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }


        public bool UpdateWeeks(WeekViewModel model)
        {
            try
            {
                Week weeks = _Context.Week.Where(x => x.WeekId == model.WeekId).FirstOrDefault();

                weeks.WeekId = model.WeekId;
                weeks.WeekName = model.WeekName;

                _Context.Week.Update(weeks);
                _Context.SaveChanges();

                string currentDates = DateTime.Now.ToShortDateString();

                DailyReport dailyReport = _Context.DailyReport.Where(x => x.CurrentDate == Convert.ToDateTime(currentDates)).FirstOrDefault();




                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool RemoveWeeks(int ? id)
        {
            try
            {
                Week weeks = _Context.Week.Where(x => x.WeekId == id).FirstOrDefault();
                _Context.Remove(weeks);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
