using HR.Leavemanagament.Application.Exceptions;
using HR.Leavemanagament.MVC.Contracts;
using HR.Leavemanagament.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Controllers
{
    [Authorize(Roles = "Administractor")]
    public class LeaveTypeController : Controller
    {
        private readonly ILogger<LeaveTypeController> _logger;
        private readonly ILeaveTypeService _leaveTypeService;
        private readonly ILeaveAllocationService _leaveAllocationService;

        public LeaveTypeController(
            ILogger<LeaveTypeController> logger, ILeaveTypeService leaveTypeService,
             ILeaveAllocationService leaveAllocationService)
        {
            _leaveTypeService = leaveTypeService;
            _logger = logger;
            _leaveAllocationService = leaveAllocationService;
        }
        public async Task<ActionResult> Index()
        {
            var model = await _leaveTypeService.GetLeaveTypes();
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _leaveTypeService.GetLeaveTypeWithDetails(id);

            return View(model);
        }

        // GET: LeaveTypesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVm leaveType)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(leaveType);
                if (response is null) throw new NotFoundException(nameof(LeaveTypeVm), leaveType.Name);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(leaveType);
        }

        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _leaveTypeService.GetLeaveTypeWithDetails(id);

            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeVm leaveType)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveType(leaveType);
                if (response is null) throw new NotFoundException(nameof(LeaveTypeVm),  leaveType.Id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(leaveType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _leaveTypeService.DeleteLeaveType(id);
                if (response is null) throw new NotFoundException(nameof(LeaveTypeVm), id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Allocate(int id)
        {
            try
            {
                var response = await _leaveAllocationService.CreateLeaveAllocations(id);
                if (response is null) throw new NotFoundException(nameof(LeaveAllocationVM), id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return BadRequest();
        }
    }
}
