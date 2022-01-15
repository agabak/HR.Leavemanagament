using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Leavemanagament.MVC.Models
{
    public class LeaveAllocationVm : CreateLeaveAllocationVm
    {
        public int Id { get; set; }
    }

    public class CreateLeaveAllocationVm
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }

    }
}
