using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public async Task<ActionResult> Index(int pageNumber=1)
        {          
            return View(await PaginatedList<Members>.CreateAsync(_Context.Members,pageNumber,5));
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