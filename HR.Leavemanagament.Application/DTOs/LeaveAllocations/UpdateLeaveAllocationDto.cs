using HR.Leavemanagament.Application.DTOs.Common;

namespace HR.Leavemanagament.Application.DTOs
{
    public class UpdateLeaveAllocationDto: BaseDto, ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
