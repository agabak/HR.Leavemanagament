using System.Collections.Generic;

namespace HR.Leavemanagament.MVC.Models
{
    public class EmployeeLeaveRequestViewVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; internal set; }
        public List<LeaveRequestVM> LeaveRequests { get; internal set; }
    }
}
