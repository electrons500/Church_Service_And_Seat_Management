using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.Services
{
    public class TemperatureService
    {
        private ServiceDBContext _Context;
       
        public TemperatureService(ServiceDBContext context)
        {
            _Context = context;
           
        }

        public List<TemperatureViewModel> GetTemperatures()
        {
            try
            {
                List<Temperature> temperatures = _Context.Temperature
                        .Include(x => x.Verify)
                        .Include(x => x.ServiceCategory)
                        .Include(x => x.Week)
                        .Include(x => x.Member)
                        .ToList();

                List<TemperatureViewModel> model = temperatures.Select(b => new TemperatureViewModel
                {
                    TemperatureId = b.TemperatureId,
                    MemberId = b.MemberId,
                    MemberName = b.Member.FullName,
                    WeekId = b.WeekId,
                    WeekName = b.Week.WeekName,
                    ServiceCategoryId = b.ServiceCategoryId,
                    ServiceCategoryName = b.ServiceCategory.ServiceCategoryName,
                    TempuratureNumber = b.TempuratureNumber,
                    CurrentDate = b.CurrentDate,
                    VerifyId = b.VerifyId,
                    VerifyName = b.Verify.VerifyName

                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<TemperatureViewModel> emptymodel = new List<TemperatureViewModel>();

                return emptymodel;
            }
        }

        public TemperatureViewModel CreateTemperature()
        {
            try
            {
                TemperatureViewModel model = new TemperatureViewModel();
                model.ServiceCategoryList = new SelectList(_Context.ServiceCategory, "ServiceCategoryId", "ServiceCategoryName");
                model.WeekList = new SelectList(_Context.Week, "WeekId", "WeekName");
                model.VerifyList = new SelectList(_Context.VerifyMember, "VerifyId", "VerifyName");

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TemperatureViewModel GetTemperatureDetails(int id)
        {
            try
            {
                Temperature temperature = _Context.Temperature
                       .Include(x => x.ServiceCategory)
                       .Include(x => x.Week)
                       .Include(x => x.Verify)
                       .Where(x => x.TemperatureId == id).FirstOrDefault();
                TemperatureViewModel model = new TemperatureViewModel
                {
                    TemperatureId = temperature.TemperatureId,
                    MemberId = temperature.MemberId,
                    WeekId = temperature.WeekId,
                    WeekList = new SelectList(_Context.Week, "WeekId", "WeekName", temperature.Week.WeekId),
                    WeekName = temperature.Week.WeekName,

                    ServiceCategoryId = temperature.ServiceCategoryId,
                    ServiceCategoryList = new SelectList(_Context.Week, "WeekId", "WeekName", temperature.ServiceCategory.ServiceCategoryId),
                    ServiceCategoryName = temperature.ServiceCategory.ServiceCategoryName,

                    TempuratureNumber = temperature.TempuratureNumber,
                    CurrentDate = temperature.CurrentDate,
                    VerifyId = temperature.VerifyId,
                    VerifyList = new SelectList(_Context.VerifyMember, "VerifyId", "VerifyName", temperature.Verify.VerifyId),
                    VerifyName = temperature.Verify.VerifyName

                };

                return model;
            }
            catch (Exception)
            {

                TemperatureViewModel emptymodel = new TemperatureViewModel();
                return emptymodel;
            }

        }

        public bool AddTemperature(TemperatureViewModel model)
        {
            try
            {
                Temperature temperature = new Temperature
                {
                    TemperatureId = model.TemperatureId,
                    MemberId = model.MemberId,
                    WeekId = model.WeekId,
                    ServiceCategoryId = model.ServiceCategoryId,
                    TempuratureNumber = model.TempuratureNumber,
                    CurrentDate = DateTime.Now,
                    VerifyId = model.VerifyId
                };

                _Context.Temperature.Add(temperature);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateTemperature(TemperatureViewModel model)
        {
            try
            {
                Temperature temperature = _Context.Temperature.Where(x => x.TemperatureId == model.TemperatureId).FirstOrDefault();

                temperature.MemberId = model.MemberId;
                temperature.WeekId = model.WeekId;
                temperature.ServiceCategoryId = model.ServiceCategoryId;
                temperature.TempuratureNumber = model.TempuratureNumber;
                temperature.CurrentDate = model.CurrentDate;
                temperature.VerifyId = model.VerifyId;

                _Context.Temperature.Update(temperature);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTemperature(int id)
        {
            try
            {
                Temperature temperature = _Context.Temperature.Where(x => x.TemperatureId == id).FirstOrDefault();
                _Context.Temperature.Remove(temperature);
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
