using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Persistance.Repositories
{
    public class LeaveRequestResposity : GenericRepository<LeaveRequest>, ILeaveRequestResposity
    {

        private readonly LeaveManagamentDBContext _dBContext;

        public LeaveRequestResposity(LeaveManagamentDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus)
        {
            leaveRequest.Approved = approvalStatus;
            _dBContext.Entry(leaveRequest).State = EntityState.Modified;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetail(int id)
        {
            var leaveRequest = await _dBContext.LeaveRequests.Include(q => q.LeaveType)
                                               .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _dBContext.LeaveRequests.Include(q => q.LeaveType)
                                                 .ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
        {
            var leaveRequests = await _dBContext.LeaveRequests.Where(q => q.RequestingEmployeeId == userId)
               .Include(q => q.LeaveType)
               .ToListAsync();
            return leaveRequests;
        }
    }
}
