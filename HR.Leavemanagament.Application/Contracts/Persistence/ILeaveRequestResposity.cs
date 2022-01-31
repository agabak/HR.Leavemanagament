using HR.Leavemanagament.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Contracts.Persistence
{
    public interface ILeaveRequestResposity
        :IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetail(int id);

        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();

        Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);

        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
    }
}
