﻿using HR.Leavemanagament.MVC.Models;
using HR.Leavemanagament.MVC.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Contracts
{
    public interface ILeaveAllocationService
    {
        Task<List<LeaveAllocationVm>> GetLeaveAllocations();

        Task<LeaveAllocationVm> GetLeaveAllocationWithDetails(int id);

        Task<Response<int>> CreateLeaveAllocation(LeaveAllocationVm leaveAllocation);

        Task<Response<int>> UpdateLeaveAllocation(UpdateLeaveAllocationVm leaveAllocation);

        Task<Response<int>> DeleteLeaveAllocation(int id);
    }
}