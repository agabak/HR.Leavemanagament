using FluentValidation;
using HR.Leavemanagament.Application.Contracts.Persistence;

namespace HR.Leavemanagament.Application.DTOs.LeaveRequests.Validators
{
    public class UpdateLeaveRequestValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestValidator(_leaveTypeRepository));

            RuleFor(p => p.Id).GreaterThan(0).WithMessage("{PropertyName} is required");
        }
    }
}
