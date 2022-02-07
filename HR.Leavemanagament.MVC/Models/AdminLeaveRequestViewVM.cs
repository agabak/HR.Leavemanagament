using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Models
{
    public class AdminLeaveRequestViewVM
    {
        public int TotalRequests { get;  set; }
        public int ApprovedRequests { get;  set; }
        public int PendingRequests { get;  set; }
        public int RejectedRequests { get;  set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
