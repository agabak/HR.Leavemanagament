using FluentValidation;
using HR.Leavemanagament.Application.Contracts.Persistence;

namespace HR.Leavemanagament.Application.DTOs.LeaveAllocations.Validators
{
    public class CreateLeaveAllocationValidator : AbstractValidator<CreateLeaveAllocationDto>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveAllocationValidator(_leaveTypeRepository));
        }
    }
}
