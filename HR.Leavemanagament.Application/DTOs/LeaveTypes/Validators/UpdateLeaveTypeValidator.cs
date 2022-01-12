using FluentValidation;

namespace HR.Leavemanagament.Application.DTOs.LeaveTypes.Validators
{
    public class UpdateLeaveTypeValidator:AbstractValidator<UpdateLeaveTypeDto>
    {
        public UpdateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDtoValidator());
        }
    }
}
