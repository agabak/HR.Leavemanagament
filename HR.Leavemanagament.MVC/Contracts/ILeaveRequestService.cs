using HR.Leavemanagament.MVC.Models;
using HR.Leavemanagament.MVC.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Contracts
{
    public interface ILeaveRequestService
    {

        Task ApproveLeaveRequest(int id, bool approved);

        Task<Response<int>> CreateLeaveRequest(CreateLeaveRequestVM leaveType);

        Task<Response<int>> DeleteLeaveRequest(int id);

        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();

        Task<LeaveRequestVM> GetLeaveRequest(int id);

        Task<List<LeaveRequestVM>> GetLeaveRequests();

        Task<LeaveRequestVM> GetLeaveRequestWithDetails(int id);

        Task<EmployeeLeaveRequestViewVM> GetUserLeaveRequests();
        
    }
}
