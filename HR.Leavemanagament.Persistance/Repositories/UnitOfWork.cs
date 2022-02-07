using HR.Leavemanagament.Application.Constants;
using HR.Leavemanagament.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Persistance.Repositories
{
    public class UnitOfWork : IUnityOfWork
    {

        private readonly LeaveManagamentDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ILeaveAllocationRepository _leaveAllocationRepository;
        private ILeaveTypeRepository _leaveTypeRepository;
        private ILeaveRequestResposity _leaveRequestRepository;


        public UnitOfWork(LeaveManagamentDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }

 
        public ILeaveAllocationRepository leaveAllocationRepository =>
            _leaveAllocationRepository ??= new LeaveAllocationRepository(_context);

        public ILeaveTypeRepository LeaveTypeRepository =>
            _leaveTypeRepository ??= new LeaveTypeRepository(_context);

        public ILeaveTypeRepository leaveTypeRepository => 
              _leaveTypeRepository ?? new LeaveTypeRepository(_context);

        public ILeaveRequestResposity leaveRequestResposity =>
            _leaveRequestRepository ?? new LeaveRequestResposity(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChanges()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}
