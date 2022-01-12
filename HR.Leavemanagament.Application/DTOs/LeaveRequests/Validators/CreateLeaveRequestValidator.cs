using FluentValidation;
using HR.Leavemanagament.Application.Contracts.Persistence;

namespace HR.Leavemanagament.Application.DTOs.LeaveRequests.Validators
{
    public class CreateLeaveRequestValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveRequestValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveRequestValidator(_leaveTypeRepository));
        }
    }
}
