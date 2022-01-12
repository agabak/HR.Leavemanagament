using HR.Leavemanagament.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Contracts.Persistence
{
    public interface ILeaveRequestResposity
        :IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetail(int id);
        Task<List<LeaveRequest>> GetLeaveRequestWithDetails();
    }
}
