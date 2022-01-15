using HR.Leavemanagament.MVC.Contracts;
using HR.Leavemanagament.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Controllers
{
    public class LeaveTypeController : Controller
    {
        private readonly ILogger<LeaveTypeController> _logger;
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypeController(ILogger<LeaveTypeController> logger, ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
            _logger = logger;
        }
        // GET: LeaveTypeController
        public async Task<ActionResult> Index()
        {
            return View( await _leaveTypeService.GetLeaveTypes());
        }

        // GET: LeaveTypeController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _leaveTypeService.GetLeaveTypeWithDetails(id));
        }

        // GET: LeaveTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVm leaveTypeVm)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(leaveTypeVm);
                if(response.Success)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError(" ", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(" ", ex.Message);
            }
            return View();
        }

        // GET: LeaveTypeController/Edit/5
        public async  Task<ActionResult> Edit(int id)
        {
           return  View(await _leaveTypeService.GetLeaveTypeWithDetails(id));
        }

        // POST: LeaveTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeVm leaveType)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveType(leaveType);
                if(response.Success)
                    return  RedirectToAction(nameof(Index));

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(" ", ex.Message); 
            }

            return View();
        }

        // GET: LeaveTypeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _leaveTypeService.GetLeaveTypeWithDetails(id));
        }

        // POST: LeaveTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var response = await _leaveTypeService.DeleteLeaveType(id);

                if(response.Success) 
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError(" ", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
    }
}
