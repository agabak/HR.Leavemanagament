using HR.Leavemanagament.Application.DTOs.Common;
using System;

namespace HR.Leavemanagament.Application.DTOs
{
    public class CreateLeaveRequestDto: ILeaveRequestDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string RequestComments { get; set; }
    }
}
