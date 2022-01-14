using HR.Leavemanagament.MVC.Models;
using HR.Leavemanagament.MVC.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Contracts
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeVm>> GetLeaveTypes();

        Task<LeaveTypeVm> GetLeaveTypeWithDetails(int id);

        Task<Response<int>> CreateLeaveType(CreateLeaveTypeVm leaveType);

        Task<Response<int>> UpdateLeaveType(LeaveTypeVm leaveType);

        Task<Response<int>> DeleteLeaveType(int id);
    }
}
