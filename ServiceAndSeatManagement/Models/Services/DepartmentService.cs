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

    }
}
