using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var _CurrentDate = DateTime.Now.ToShortDateString();

            try
            {
                List<Temperature> temperatures = _Context.Temperature
                        .Include(x => x.Verify)                    
                        .Include(x => x.Member)
                        .Where(x => x.CurrentDate == Convert.ToDateTime(_CurrentDate))
                        .ToList();

                List<TemperatureViewModel> model = temperatures.Select(b => new TemperatureViewModel
                {
                    TemperatureId = b.TemperatureId,
                    MemberId = b.MemberId,
                    MemberName = b.Member.FullName,                   
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
                      
                       .Include(x => x.Verify)
                       .Where(x => x.TemperatureId == id).FirstOrDefault();
                TemperatureViewModel model = new TemperatureViewModel
                {
                    TemperatureId = temperature.TemperatureId,
                    MemberId = temperature.MemberId,
                  
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
                    MemberId = model.MemberId,
                    TempuratureNumber = model.TempuratureNumber,
                    CurrentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    VerifyId = model.VerifyId
                };

                _Context.Temperature.Add(temperature);
                _Context.SaveChanges();


               

                return true;
            }
            catch (Exception)
            {
                throw new Exception();
            }


        }

        public bool UpdateTemperature(TemperatureViewModel model)
        {
            try
            {
                Temperature temperature = _Context.Temperature.Where(x => x.TemperatureId == model.TemperatureId).FirstOrDefault();

                temperature.MemberId = model.MemberId;
               
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
