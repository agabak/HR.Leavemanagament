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

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
        {
            var leaveAllocations = await _dBContext.leaveAllocations.Include(a => a.LeaveType)
                                                   .ToListAsync();
            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetail(int id)
        {
            var leaveAllocation = await _dBContext.leaveAllocations.Include(a => a.LeaveType)
                                                  .FirstOrDefaultAsync(a => a.Id == id);

            return leaveAllocation;
        }
    }
}
