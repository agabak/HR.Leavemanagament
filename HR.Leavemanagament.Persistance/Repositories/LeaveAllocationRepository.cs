using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Persistance.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagamentDBContext _dBContext;

        public LeaveAllocationRepository(LeaveManagamentDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public Task AddAllocations(List<LeaveAllocation> allocations)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AllocationExists(string userId, int leaveTypeid, int period)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _dBContext.leaveAllocations.Include(a => a.LeaveType)
                                                   .ToListAsync();
            return leaveAllocations;
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetail(int id)
        {
            var leaveAllocation = await _dBContext.leaveAllocations.Include(a => a.LeaveType)
                                                  .FirstOrDefaultAsync(a => a.Id == id);

            return leaveAllocation;
        }

        public Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId)
        {
            throw new System.NotImplementedException();
        }
    }
}
