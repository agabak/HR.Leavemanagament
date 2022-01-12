using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Domain;

namespace HR.Leavemanagament.Persistance.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagamentDBContext _dBContext;

        public LeaveTypeRepository(LeaveManagamentDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }
    }
}
