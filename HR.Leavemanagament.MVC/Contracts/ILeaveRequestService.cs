using HR.Leavemanagament.MVC.Models;
using HR.Leavemanagament.MVC.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Contracts
{
    public interface ILeaveRequestService
    {
        Task<List<LeaveRequestListVm>> GetLeaveRequests();

        Task<LeaveRequestVm> GetLeaveRequestWithDetails(int id);

        Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVm leaveType);

        Task<Response<int>> UpdateLeaveRequest(UpdateLeaveRequestVm leaveType);

        Task<Response<int>> DeleteLeaveRequest(int id);
    }
}
