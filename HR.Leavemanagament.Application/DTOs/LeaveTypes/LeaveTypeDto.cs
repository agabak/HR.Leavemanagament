using HR.Leavemanagament.Application.DTOs.Common;

namespace HR.Leavemanagament.Application.DTOs
{
    public class LeaveTypeDto: BaseDto, ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
