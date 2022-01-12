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
    }
}
