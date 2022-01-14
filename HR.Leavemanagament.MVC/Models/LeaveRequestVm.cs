using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Models
{
  
    public class LeaveRequestVm : CreateLeaveRequestVm
    {
        public int Id { get; set; }
        public DateTime? DateRequested { get; set; }
        public DateTime? DateActioned { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
    }

    public class UpdateLeaveRequestVm : CreateLeaveRequestVm
    {
        public int Id { get; set; }
        public DateTime? DateRequested { get; set; }
        public bool Cancelled { get; set; }
    }

    public class CreateLeaveRequestVm
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; }
    }
}
