using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _dBContext.AddRangeAsync(allocations);
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeid, int period)
        {
            return await _dBContext.leaveAllocations.AnyAsync(q => q.EmployeeId == userId 
                                                              && q.LeaveTypeId == leaveTypeid
                                                              && q.Period == period);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            return await _dBContext.leaveAllocations.Include(a => a.LeaveType)
                                                   .ToListAsync();
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            return await _dBContext.leaveAllocations.Where(q => q.EmployeeId == userId)
             .Include(q => q.LeaveType)
             .ToListAsync();
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetail(int id)
        {
            var leaveAllocation = await _dBContext.leaveAllocations.Include(a => a.LeaveType)
                                                  .FirstOrDefaultAsync(a => a.Id == id);

            return leaveAllocation;
        }

        public async Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId)
        {
            return await _dBContext.leaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                        && q.LeaveTypeId == leaveTypeId);
        }
    }
}
