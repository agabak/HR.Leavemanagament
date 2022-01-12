using FluentValidation;

namespace HR.Leavemanagament.Application.DTOs.LeaveTypes.Validators
{
    public class CreateLeaveTypeValidator: AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDtoValidator());
        }
    }
}
