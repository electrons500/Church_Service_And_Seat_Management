using ServiceAndSeatManagement.Models.Data.ServiceDBContext;
using ServiceAndSeatManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ServiceAndSeatManagement.Models.Services
{
    public class VerifyMemberService
    {
        private ServiceDBContext _Context;
        public VerifyMemberService(ServiceDBContext context)
        {
            _Context = context;
        }

        public List<VerifyMemberViewModel> GetVerified()
        {
            try
            {
                var verify = _Context.VerifyMember.ToList();
                List<VerifyMemberViewModel> model = verify.Select(x => new VerifyMemberViewModel
                {
                    VerifyId = x.VerifyId,
                    VerifyName = x.VerifyName
                }).ToList();

                return model;
            }
            catch (Exception)
            {

                List<VerifyMemberViewModel> emptymodel = new List<VerifyMemberViewModel>();
                return emptymodel;
            }
        }

        public VerifyMemberViewModel GetVerifyMemberDetail(int id)
        {
            try
            {
                VerifyMember verify = _Context.VerifyMember.Where(x => x.VerifyId == id).FirstOrDefault();

                VerifyMemberViewModel model = new VerifyMemberViewModel
                {
                    VerifyId = verify.VerifyId,
                    VerifyName = verify.VerifyName
                };

                return model;
            }
            catch (Exception)
            {

                VerifyMemberViewModel emptymodel = new VerifyMemberViewModel();
                return emptymodel;

            }
        }

        public bool UpdateVerifyMember(VerifyMemberViewModel model)
        {
            try
            {
                VerifyMember verify = _Context.VerifyMember.Where(x => x.VerifyId == model.VerifyId).FirstOrDefault();
                verify.VerifyId = model.VerifyId;
                verify.VerifyName = model.VerifyName;

                _Context.VerifyMember.Update(verify);
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
