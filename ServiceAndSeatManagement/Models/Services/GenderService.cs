using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.Services
{
    public class GenderService
    {
        private ServiceDBContext _Context;
        public GenderService(ServiceDBContext context)
        {
            _Context = context;
        }

        public List<GenderViewModel> GetGenders()
        {
            try
            {
                var Genders = _Context.Gender.ToList();
                List<GenderViewModel> model = Genders.Select(x => new GenderViewModel
                {
                    GenderId = x.GenderId,
                    GenderName = x.GenderName
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<GenderViewModel> emptymodel = new List<GenderViewModel>();
                return emptymodel;
            }
        }


    }
}
