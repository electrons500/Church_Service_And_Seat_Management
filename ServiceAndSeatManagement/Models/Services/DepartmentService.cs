using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.Services
{
    public class DepartmentService
    {
       private ServiceDBContext _Context;

        public DepartmentService( ServiceDBContext context)
        {
            _Context = context;
        }

        public bool AddDepartment(DepartmentViewModel model)
        {
            try
            {
                Department department = new Department
                {
                    DepartmentId = model.DepartmentId,
                    DepartmentName = model.DepartmentName
                };

                _Context.Department.Add(department);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }

           
        }

        public bool UpdateDepartment(DepartmentViewModel model)
        {
            try
            {
                Department department = _Context.Department.Where(x => x.DepartmentId == model.DepartmentId).FirstOrDefault();
                department.DepartmentName = model.DepartmentName;
                _Context.Department.Update(department);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveDepartment(int id)
        {
            try
            {
                Department department = _Context.Department.Where(x => x.DepartmentId == id).FirstOrDefault();
                _Context.Department.Remove(department);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Is left with creating list of department and get Department
        public List<DepartmentViewModel> GetDepartments()
        {
            try
            {
                var departments = _Context.Department.ToList();
                List<DepartmentViewModel> model = departments.Select(x => new DepartmentViewModel
                {
                   DepartmentId = x.DepartmentId,
                   DepartmentName = x.DepartmentName

                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<DepartmentViewModel> emptymodel = new List<DepartmentViewModel>();
                return emptymodel;
            }

        }

        public DepartmentViewModel GetDepartmentDetails(int? id)
        {
            try
            {
               Department departments = _Context.Department.Where(x => x.DepartmentId == id).FirstOrDefault();
                DepartmentViewModel model = new DepartmentViewModel
                {
                   DepartmentId  = departments.DepartmentId,
                    DepartmentName = departments.DepartmentName
                };

                return model;
            }
            catch (Exception)
            {
               DepartmentViewModel emptymodel = new DepartmentViewModel();
                return emptymodel;

            }
        }

    }
}
