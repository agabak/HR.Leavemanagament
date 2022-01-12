using HR.Leavemanagament.Application.DTOs.Common;
using System;

namespace HR.Leavemanagament.Application.DTOs
{
    public class LeaveRequestListDto: BaseDto
    {
       
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Approved { get; set; }

    }
}
