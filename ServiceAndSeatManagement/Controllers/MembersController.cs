using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using ServiceAndSeatManagement.Models;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.Services;
using ServiceAndSeatManagement.Models.ViewModel;
using static ServiceAndSeatManagement.Models.Enum;


namespace ServiceAndSeatManagement.Controllers
{
    
   
    public class MembersController : BaseController
    {
        private MembersService _MembersService;
        private TemperatureService _TemperatureService;
        private ServiceDBContext _Context;
      
        public MembersController(MembersService membersService,TemperatureService temperatureService,ServiceDBContext context)
        {
            _MembersService = membersService;
            _TemperatureService = temperatureService;
            _Context = context;
        }
        // GET: Members
       
        public ActionResult Index()
        {
            
            //data to dropdownlist
            var model = _MembersService.CreateMembers();
            return View(model);
        }

        // GET: Members/Details/5
        public ActionResult Details(int id)
        {
            var model = _MembersService.GetMembersDetails(id);
            if(model == null)
            {
                return View();
            }
            else
            {
                return View(model);
            }

           
        }

        // GET: Members/Create

        public ActionResult Create()
        {
            var model = _MembersService.CreateMembers();
            return View(model);
        }

        // POST: Members/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MembersViewModel model)
        {
           
            try
            {
                if(model == null)
                {
                    return RedirectToAction(nameof(ErrorMessage));
                }
               
                
                bool result = _MembersService.AddMembers(model);
                if (result)
                {

                    Alert("Congratulations", "New member successfully added!", NotificationType.success);
                    
                    
                }
                return RedirectToAction(nameof(Index));

                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _MembersService.GetMembersDetails(id);

            return View(model);
        }

        // POST: Members/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MembersViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return RedirectToAction(nameof(ErrorMessage));
                }


                bool result = _MembersService.UpdateMembers(model);
                if (result)
                {
                    Alert("Congratulations", "Member information successfully updated!", NotificationType.success);

                }
                else
                {
                    return RedirectToAction(nameof(ErrorMessage));
                }
                return RedirectToAction(nameof(MembersLists));
                throw new Exception();
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _MembersService.GetMembersDetails(id);

            return View(model);
        }

        // POST: Members/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                
                bool result = _MembersService.DeleteMember(id);
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
      
        [HttpGet]
        public ActionResult GetMembersData()
        {          
           
            var model = _MembersService.GetMembers();
            
            return Json(new { data = model });
        }

        public ActionResult MembersLists()
        {
           

            return View();
        }
        
        [HttpPost]
        public ActionResult SaveTemperature()
        {
            //Get data from View to controller
            var memberNo = Request.Form["txtMemberId"].ToString();
            var memberTemperature = Request.Form["txtTemperature"].ToString();
           
                try
                {
                            decimal a = Convert.ToDecimal(memberTemperature);
                            if (a <= 1) {

                                return RedirectToAction(nameof(ErrorMessage));
                            }


                            TemperatureViewModel model = new TemperatureViewModel
                            {
                                MemberId = Convert.ToInt32(memberNo),
                                TempuratureNumber = Convert.ToDecimal(memberTemperature),
                                //verifyNumber must set to Yes which 2 in the DB
                                VerifyId = 2

                             };


               
                            bool result = _TemperatureService.AddTemperature(model);
                            if (result)
                            {
                                Alert("Congratulations", "Temperature successfully recorded!", NotificationType.success);

                            }
                            else
                            {
                                Alert("Error","Temperature Failed to be recorded!", NotificationType.error);
                            }

                            return RedirectToAction(nameof(Index));
                        

                }
                catch (FormatException)
                {
                    return RedirectToAction(nameof(ErrorMessage));
                }
                catch (Exception)
                {

                    throw;

                }
            
        }
        
        
        public ActionResult ErrorMessage()
        {
            Alert("Error", "Error message page", NotificationType.error);
            return View();
        }


        public bool IsNumeric(object values)
        {
            try
            {
                int i = Convert.ToInt32(values.ToString());

                return true;
            }
            catch (FormatException)
            {

                return false;
            }
        }
       

    }
}