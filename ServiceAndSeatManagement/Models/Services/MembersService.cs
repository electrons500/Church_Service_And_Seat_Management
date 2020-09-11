using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.Services
{
    public class MembersService
    {
        private ServiceDBContext _Context;
        private GenderService _GenderService;
        private DepartmentService _DepartmentService;
       
        public MembersService(ServiceDBContext context,GenderService genderService,DepartmentService departmentService)
        {
            _Context = context;
            _GenderService = genderService;
            _DepartmentService = departmentService;
           
        }

        public MembersViewModel CreateMembers()
        {
            try
            {
                MembersViewModel model = new MembersViewModel();
                List<GenderViewModel> genders = _GenderService.GetGenders();
                List<DepartmentViewModel> departments = _DepartmentService.GetDepartments();
               

                SelectList genderList = new SelectList(genders, "GenderId", "GenderName");
                SelectList departmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
               
                model.GenderList = genderList;
                model.DepartmentList = departmentList;
               

                return model;

            }
            catch (Exception)
            {
                MembersViewModel emptymodel = new MembersViewModel();
                return emptymodel;
            }
        }

        public List<MembersViewModel> GetMembers()
        {
            try
            {
                List<Members> members = _Context.Members
                    .Include(x => x.Gender)
                    .Include(x => x.Department)
                    
                    .ToList();
              
                List<MembersViewModel> model = members.Select(x => new MembersViewModel
                {
                    MemberId = x.MemberId,
                    FullName = x.FullName,
                    Age = x.Age,
                    GenderId = x.GenderId,
                    GenderName = x.Gender.GenderName,
                    Residence = x.Residence,
                    DigitalAddress = x.DigitalAddress,
                    PhoneNumber = x.PhoneNumber,
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.Department.DepartmentName,
                  
                    CurrentDate = x.CurrentDate
                   

                }).ToList();


                return model;
            }
            catch (Exception)
            {

                List<MembersViewModel> emptymodel = new List<MembersViewModel>();

                return emptymodel;
               
            }
        }

        public MembersViewModel GetMembersDetails(int id)
        {
            try
            {
                Members members = _Context.Members
                        .Where(x => x.MemberId == id)
                        .Include(x => x.Gender)
                        .Include(x => x.Department)
                       
                        .FirstOrDefault();

                MembersViewModel model = new MembersViewModel
                {
                    MemberId = members.MemberId,
                 
                    FullName = members.FullName,
                    Age = members.Age,
                    GenderId = members.GenderId,
                    GenderName = members.Gender.GenderName,
                    GenderList = new SelectList(_GenderService.GetGenders(), "GenderId", "GenderName"),
                    DigitalAddress = members.DigitalAddress,
                    Residence = members.Residence,
                    PhoneNumber = members.PhoneNumber,
                    DepartmentId = members.DepartmentId,
                    DepartmentName = members.Department.DepartmentName,
                    DepartmentList = new SelectList(_DepartmentService.GetDepartments(), "DepartmentId", "DepartmentName"),
                   
                    CurrentDate = members.CurrentDate
                };

                return model;
            }
            catch (Exception)
            {
                //MembersViewModel emptymodel = new MembersViewModel();

                //return emptymodel;
                throw;
            }
        }

        public bool AddMembers(MembersViewModel model)
        {
            string MemberDigitalAddress;


            try
            {
                if(model.DigitalAddress == null)
                {
                    MemberDigitalAddress = "None";
                    model.DigitalAddress = MemberDigitalAddress;
                }
                else
                {
                    MemberDigitalAddress = model.DigitalAddress;
                }
               
                Members members = new Members
                {                   
                    FullName = model.FullName.ToUpper(),
                    Age = model.Age,
                    GenderId = model.GenderId,
                    Residence = model.Residence,
                    DigitalAddress = MemberDigitalAddress,
                    PhoneNumber = model.PhoneNumber,
                    DepartmentId = model.DepartmentId,                 
                    CurrentDate = DateTime.Now

                };

                _Context.Members.Add(members);
                _Context.SaveChanges();


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public bool UpdateMembers(MembersViewModel model)
        {
            try
            {
                Members members = _Context.Members.Where(x => x.MemberId == model.MemberId).FirstOrDefault();
                members.MemberId = model.MemberId;              
                members.FullName = model.FullName.ToUpper();
                members.Age = model.Age;
                members.GenderId = model.GenderId;
                members.Residence = model.Residence;
                members.DigitalAddress = model.DigitalAddress;
                members.PhoneNumber = model.PhoneNumber;
                members.DepartmentId = model.DepartmentId;
               
                //members.SeatNumber = model.SeatNumber;

                _Context.Members.Update(members);
                _Context.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
            
        }

        public bool DeleteMember(int id)
        {
            try
            {
                Members members = _Context.Members.Where(x => x.MemberId == id).FirstOrDefault();
                _Context.Members.Remove(members);
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
