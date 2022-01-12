using HR.Leavemanagament.Domain.Common;

namespace HR.Leavemanagament.Domain
{
    public class LeaveType: BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
