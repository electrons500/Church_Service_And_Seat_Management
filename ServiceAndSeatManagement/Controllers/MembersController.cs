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

namespace ServiceAndSeatManagement.Controllers
{
    
   
    public class MembersController : Controller
    {
        private MembersService _MembersService;
        private ServiceDBContext _Context;
        public MembersController(MembersService membersService,ServiceDBContext context)
        {
            _MembersService = membersService;
            _Context = context;
        }
        // GET: Members
       
        public ActionResult Index(string searchString,int pageNumber=1,int pageSize=5)
        {
            int ExcludeRecords = (pageNumber * pageSize) - pageSize;
            var members = from b in _Context.Members.Include(x => x.ServiceCategory)
                          select b;

            //counts all members registered
            var memberCount = members.Count();

            //code for filtering
            if (!String.IsNullOrEmpty(searchString))
            {
                members = members.Where(x => x.FullName.Contains(searchString));
                memberCount = members.Count();
                
            }

            //code for pagination and arranging fullname ascending order of alphabet
            members = members.OrderBy(b => b.FullName).Skip(ExcludeRecords).Take(pageSize);

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
                    return RedirectToAction(nameof(Index));
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
    }
}