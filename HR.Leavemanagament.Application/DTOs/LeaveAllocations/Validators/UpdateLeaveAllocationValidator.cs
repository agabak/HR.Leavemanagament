using FluentValidation;
using HR.Leavemanagament.Application.Contracts.Persistence;

namespace HR.Leavemanagament.Application.DTOs.LeaveAllocations.Validators
{
    public class UpdateLeaveAllocationValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveAllocationValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveAllocationValidator(_leaveTypeRepository));
        }
    }
}
