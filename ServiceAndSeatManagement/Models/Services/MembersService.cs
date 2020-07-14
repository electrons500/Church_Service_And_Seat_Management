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
        private ServiceCategoryService _ServiceCategoryService;
        public MembersService(ServiceDBContext context,GenderService genderService,DepartmentService departmentService,ServiceCategoryService serviceCategoryService)
        {
            _Context = context;
            _GenderService = genderService;
            _DepartmentService = departmentService;
            _ServiceCategoryService = serviceCategoryService;
        }

        public MembersViewModel CreateMembers()
        {
            try
            {
                MembersViewModel model = new MembersViewModel();
                List<GenderViewModel> genders = _GenderService.GetGenders();
                List<DepartmentViewModel> departments = _DepartmentService.GetDepartments();
                List<ServiceCategoryViewModel> serviceCategories = _ServiceCategoryService.GetServiceCategories();

                SelectList genderList = new SelectList(genders, "GenderId", "GenderName");
                SelectList departmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
                SelectList ServiceCategoryList = new SelectList(serviceCategories, "ServiceCategoryId", "ServiceCategoryName");

                model.GenderList = genderList;
                model.DepartmentList = departmentList;
                model.ServiceCategoryList = ServiceCategoryList;

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
                    .Include(x => x.ServiceCategory)
                    .ToList();

                List<MembersViewModel> model = members.Select(x => new MembersViewModel
                {
                    MemberId = x.MemberId,
                    Surname = x.Surname,
                    Othernames = x.Othernames,
                    FullName = x.FullName,
                    Age = x.Age,
                    GenderId = x.GenderId,
                    GenderName = x.Gender.GenderName,
                    DigitalAddress = x.DigitalAddress,
                    PhoneNumber = x.PhoneNumber,
                    DepartmentId = x.DepartmentId,
                    DepartmentName = x.Department.DepartmentName,
                    ServiceCategoryId = x.ServiceCategoryId,
                    ServiceCategoryName = x.ServiceCategory.ServiceCategoryName,
                    SeatNumber = x.SeatNumber,
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
                        .Include(x => x.ServiceCategory)
                        .FirstOrDefault();

                MembersViewModel model = new MembersViewModel
                {
                    MemberId = members.MemberId,
                    Surname = members.Surname,
                    Othernames = members.Othernames,
                    FullName = members.FullName,
                    Age = members.Age,
                    GenderId = members.GenderId,
                    GenderName = members.Gender.GenderName,
                    DigitalAddress = members.DigitalAddress,
                    PhoneNumber = members.PhoneNumber,
                    DepartmentId = members.DepartmentId,
                    DepartmentName = members.Department.DepartmentName,
                    ServiceCategoryId = members.ServiceCategoryId,
                    ServiceCategoryName = members.ServiceCategory.ServiceCategoryName,
                    SeatNumber = members.SeatNumber,
                    CurrentDate = members.CurrentDate
                };

                return model;
            }
            catch (Exception)
            {
                MembersViewModel emptymodel = new MembersViewModel();

                return emptymodel;
            }
        }

        public bool AddMembers(MembersViewModel model)
        {
            try
            {
                Members members = new Members
                {
                    MemberId = model.MemberId,
                    Surname = model.Surname,
                    Othernames = model.Othernames,
                    FullName = $"{ model.Surname.ToUpper()} { model.Othernames}",
                    Age = model.Age,
                    GenderId = model.GenderId,
                    DigitalAddress = model.DigitalAddress,
                    PhoneNumber = model.PhoneNumber,
                    DepartmentId = model.DepartmentId,
                    ServiceCategoryId = model.ServiceCategoryId,
                    SeatNumber = model.SeatNumber,
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
                members.Surname = model.Surname;
                members.Othernames = model.Othernames;
                members.FullName = $"{model.Surname.ToUpper()} {model.Othernames}";
                members.Age = model.Age;
                members.GenderId = model.GenderId;
                members.DigitalAddress = model.DigitalAddress;
                members.PhoneNumber = model.PhoneNumber;
                members.DepartmentId = model.DepartmentId;
                members.ServiceCategoryId = model.ServiceCategoryId;
                members.SeatNumber = model.SeatNumber;

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
