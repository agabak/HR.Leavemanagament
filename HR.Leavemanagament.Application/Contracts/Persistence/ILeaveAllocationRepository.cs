using HR.Leavemanagament.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository
        : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetail(int id);

        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails();

        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);

        Task<bool> AllocationExists(string userId, int leaveTypeid, int period);

        Task AddAllocations(List<LeaveAllocation> allocations);

        Task<LeaveAllocation> GetUserAllocation(string userId, int leaveTypeId);
    }
}
