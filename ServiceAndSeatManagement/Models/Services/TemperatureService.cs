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
        private int ReportId,CountMembersInFirstService, CountMembersInSecondService, CountMembersInThirdService, CountMembersInFourthService,TotalMembers;


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
                    MemberId = model.MemberId,
                    WeekId = model.WeekId,
                    ServiceCategoryId = model.ServiceCategoryId,
                    TempuratureNumber = model.TempuratureNumber,
                    CurrentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    VerifyId = model.VerifyId
                };

                _Context.Temperature.Add(temperature);
                _Context.SaveChanges();


                //  Insert or update DailyReport table by counting the number of members registered in every sunday 3 services and dated 


                string currentDates = DateTime.Now.ToShortDateString();

                DailyReport dailyReport = _Context.DailyReport.Where(x => x.CurrentDate == Convert.ToDateTime(currentDates)).FirstOrDefault();

               
                var dailyService = _Context.DailyReport.Where(x => x.CurrentDate == Convert.ToDateTime(currentDates));
                var dialyServiceMenberCount = dailyService.Count();

                int ServiceCategoryNumber = Convert.ToInt32(model.ServiceCategoryId);

                if (dialyServiceMenberCount == 0)
                {
                  // Get the intial values from the db Context to the variables

                    CountMembersInFirstService = 0;
                    CountMembersInSecondService = 0;
                    CountMembersInThirdService = 0;
                    CountMembersInFourthService = 0;


                    switch (ServiceCategoryNumber)
                    {
                        case 1:
                            CountMembersInFirstService += 1;
                            break;
                        case 2:
                            CountMembersInSecondService += 1;
                            break;
                        case 3:
                            CountMembersInThirdService += 1;
                            break;

                        default:
                            CountMembersInFourthService += 1;
                            break;

                    }

                    TotalMembers = CountMembersInFirstService + CountMembersInSecondService + CountMembersInThirdService;

                    DailyReport InsertReport = new DailyReport
                    {
                        Service1 = CountMembersInFirstService.ToString(),
                        Service2 = CountMembersInSecondService.ToString(),
                        Service3 = CountMembersInThirdService.ToString(),
                        Service4 = CountMembersInFourthService.ToString(),
                        WeekId = model.WeekId,
                        CurrentDate = Convert.ToDateTime(currentDates),
                        Total = TotalMembers.ToString()
                        

                    };

                    _Context.DailyReport.Add(InsertReport);
                    _Context.SaveChanges();

                }
                else
                {

                    // Insert a new record if no record is found on the current sunday date

                    CountMembersInFirstService = int.Parse(dailyReport.Service1);
                    CountMembersInSecondService = int.Parse(dailyReport.Service2);
                    CountMembersInThirdService = int.Parse(dailyReport.Service3);
                    CountMembersInFourthService = int.Parse(dailyReport.Service4);

                    
                     switch (ServiceCategoryNumber)
                     {
                        case 1:
                            CountMembersInFirstService += 1;
                        break;
                        case 2:
                            CountMembersInSecondService += 1;
                        break;
                        case 3:
                                CountMembersInThirdService += 1;
                        break;

                         default:
                                 CountMembersInFourthService += 1;
                        break;

                     }


                    TotalMembers = CountMembersInFirstService + CountMembersInSecondService + CountMembersInThirdService;

                    ReportId = dailyReport.ReportId;
                    DailyReport UpdateReport = _Context.DailyReport.Where(b => b.ReportId == ReportId).FirstOrDefault();
                    UpdateReport.Service1 = CountMembersInFirstService.ToString();
                    UpdateReport.Service2 = CountMembersInSecondService.ToString();
                    UpdateReport.Service3 = CountMembersInThirdService.ToString();
                    UpdateReport.Total = TotalMembers.ToString();

                    _Context.Update(UpdateReport);
                    _Context.SaveChanges();


                }

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
