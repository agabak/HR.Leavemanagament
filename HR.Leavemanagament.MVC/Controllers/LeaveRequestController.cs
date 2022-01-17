using AutoMapper;
using HR.Leavemanagament.MVC.Contracts;
using HR.Leavemanagament.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Controllers
{
    public class LeaveRequestController : Controller
    {
        private readonly ILeaveRequestService _leaveRequestService;
        private readonly IMapper _mapper;

        public LeaveRequestController(ILeaveRequestService leaveRequestService, IMapper mapper)
        {
            _leaveRequestService = leaveRequestService;
            _mapper = mapper;
        }
        // GET: HomeController1
        public async Task<ActionResult> Index()
        {
            return View(await _leaveRequestService.GetLeaveRequests());
        }

        // GET: HomeController1/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _leaveRequestService.GetLeaveRequestWithDetails(id));
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveRequestVm leaveRequestVm)
        {
            try
            {
                var response = await _leaveRequestService
                                      .CreateLeaveRequest(leaveRequestVm);

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

        // GET: HomeController1/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var leaveRquest = await _leaveRequestService.GetLeaveRequestWithDetails(id);
            return View(_mapper.Map<UpdateLeaveRequestVm>(leaveRquest));
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, UpdateLeaveRequestVm  leaveRequestVm)
        {
            try
            {
               
                var response = await _leaveRequestService.UpdateLeaveRequest(leaveRequestVm);

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

        // GET: HomeController1/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _leaveRequestService.GetLeaveRequestWithDetails(id));
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var response = await _leaveRequestService.DeleteLeaveRequest(id);
                if(response.Success)
                    return RedirectToAction(nameof(Index));

                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(" ", ex.Message);
            }
            return View();
        }
    }
}
