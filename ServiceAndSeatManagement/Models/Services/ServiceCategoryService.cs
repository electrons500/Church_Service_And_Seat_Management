using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.Services
{
    public class ServiceCategoryService
    {
        private ServiceDBContext _Context;
        public ServiceCategoryService(ServiceDBContext context)
        {
            _Context = context;
        }

        public List<ServiceCategoryViewModel> GetServiceCategories()
        {
            try
            {
                var servicecategories = _Context.ServiceCategory.ToList();
                List<ServiceCategoryViewModel> model = servicecategories.Select(x => new ServiceCategoryViewModel
                {
                    ServiceCategoryId = x.ServiceCategoryId,
                    ServiceCategoryName = x.ServiceCategoryName,
                    MemberCounts = x.MemberCounts
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<ServiceCategoryViewModel> emptymodel = new List<ServiceCategoryViewModel>();
                return emptymodel;
            }
        }

        public ServiceCategoryViewModel GetServiceCategoryDetails(int id)
        {
            try
            {
                ServiceCategory category = _Context.ServiceCategory.Where(x => x.ServiceCategoryId == id).FirstOrDefault();
                ServiceCategoryViewModel model = new ServiceCategoryViewModel
                {
                    ServiceCategoryId = category.ServiceCategoryId,
                    ServiceCategoryName = category.ServiceCategoryName

                };

                return model;
            }
            catch (Exception)
            {
                ServiceCategoryViewModel emptymodel = new ServiceCategoryViewModel();
                return emptymodel;
                
            }
        }


        public bool AddService(ServiceCategoryViewModel model)
        {

            try
            {
                ServiceCategory category = new ServiceCategory
                {
                    ServiceCategoryId = model.ServiceCategoryId,
                    ServiceCategoryName = model.ServiceCategoryName
                };

                _Context.ServiceCategory.Add(category);
                _Context.SaveChanges();

                return true;


            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateService(ServiceCategoryViewModel model)
        {
            try
            {
                ServiceCategory category = _Context.ServiceCategory.Where(x => x.ServiceCategoryId == model.ServiceCategoryId).FirstOrDefault();
                category.ServiceCategoryId = model.ServiceCategoryId;
                category.ServiceCategoryName = model.ServiceCategoryName;
                category.MemberCounts = model.MemberCounts;

                _Context.ServiceCategory.Update(category);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        private bool DeleteService(int id)
        {
            try
            {
                ServiceCategory category = _Context.ServiceCategory.Where(x => x.ServiceCategoryId == id).FirstOrDefault();
                _Context.ServiceCategory.Remove(category);
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
