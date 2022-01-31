using HR.Leavemanagament.Domain.Common;

namespace HR.Leavemanagament.Domain
{
    public class Employee : BaseDomainEntity
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}