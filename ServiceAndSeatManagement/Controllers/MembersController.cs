using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
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
        private ServiceDBContext _Context;
      
        public MembersController(MembersService membersService,ServiceDBContext context)
        {
            _MembersService = membersService;
            _Context = context;
        }
        // GET: Members
       
        public ActionResult Index(string searchString,int pageNumber=1,int pageSize=10)
        {
           

            int ExcludeRecords = (pageNumber * pageSize) - pageSize;
            // var members = _Context.Members.OrderBy(x =>x.FullName).Skip(ExcludeRecords).Take(pageSize);
            var members = from b in _Context.Members
                          select b;

            var memberCount = members.Count();

            if (!String.IsNullOrEmpty(searchString))
            {
                if (IsNumeric(searchString))
                {
                    members = members.Where(x => x.MemberId == Convert.ToInt32(searchString));
                    memberCount = members.Count();
                }
                else
                {
                    members = members.Where(x => x.FullName.Contains(searchString));
                    memberCount = members.Count();
                }
            }
            
            

            members = members.OrderBy(x => x.FullName).Skip(ExcludeRecords).Take(pageSize);
            var result = new PagedResult<Members>
            {
                Data = members.AsNoTracking().ToList(),
                TotalItems = memberCount,
                PageNumber = pageNumber,
                PageSize = pageSize
                
            };
                                 

            return View(result);
        }

        // GET: Members/Details/5
        public ActionResult Details(int id)
        {
            var model = _MembersService.GetMembersDetails(id);

            return View(model);
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

                bool result = _MembersService.AddMembers(model);
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
                bool result = _MembersService.UpdateMembers(model);
                if (result)
                {
                    return RedirectToAction(nameof(MembersLists));
                }

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
      
        public ActionResult MembersLists(string searchName, int page = 1, int pageIndex = 10)
        {
            int ExcludeRecords = (page * pageIndex) - pageIndex;
            // var members = _Context.Members.OrderBy(x =>x.FullName).Skip(ExcludeRecords).Take(pageSize);
            var members = from b in _Context.Members
                          select b;

            var memberCount = members.Count();

            if (!String.IsNullOrEmpty(searchName))
            {
                if (IsNumeric(searchName))
                {
                    members = members.Where(x => x.MemberId == Convert.ToInt32(searchName));
                    memberCount = members.Count();
                }
                else
                {
                    members = members.Where(x => x.FullName.Contains(searchName));
                    memberCount = members.Count();
                }
            }



            members = members.OrderBy(x => x.FullName).Skip(ExcludeRecords).Take(pageIndex);
            var result = new PagedResult<Members>
            {
                Data = members.AsNoTracking().ToList(),
                TotalItems = memberCount,
                PageNumber = page,
                PageSize = pageIndex

            };


            return View(result);
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