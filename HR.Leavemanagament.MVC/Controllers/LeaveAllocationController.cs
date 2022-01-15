using HR.Leavemanagament.MVC.Contracts;
using HR.Leavemanagament.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Controllers
{
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveAllocationService _leaveAllocationService;

        public LeaveAllocationController(ILeaveAllocationService leaveAllocationService)
        {
            _leaveAllocationService = leaveAllocationService;
        }

        // GET: LeaveAllocationController
        public async Task<ActionResult> Index()
        {
            return View(await _leaveAllocationService.GetLeaveAllocations());
        }

        // GET: LeaveAllocationController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _leaveAllocationService
                             .GetLeaveAllocationWithDetails(id));
        }

        // GET: LeaveAllocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveAllocationVm leaveAllocationVm)
        {
            try
            {
                var response = await _leaveAllocationService
                                      .CreateLeaveAllocation(leaveAllocationVm);
                if(response.Success)
                     return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message); 
            }
            return View();
        }

        // GET: LeaveAllocationController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _leaveAllocationService
                       .GetLeaveAllocationWithDetails(id));
        }

        // POST: LeaveAllocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveAllocationVm leaveAllocationVm)
        {
            try
            {
                var response = await _leaveAllocationService
                                     .UpdateLeaveAllocation(leaveAllocationVm);
                if(response.Success)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

        // GET: LeaveAllocationController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _leaveAllocationService
                             .GetLeaveAllocationWithDetails(id));
        }

        // POST: LeaveAllocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var response = await _leaveAllocationService
                                   .DeleteLeaveAllocation(id);
                if(response.Success)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
    }
}
