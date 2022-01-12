using FluentValidation;

namespace HR.Leavemanagament.Application.DTOs.LeaveTypes.Validators
{
    public class ILeaveTypeDtoValidator:AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull()
                                .WithMessage("{PropertyName} is required");

            RuleFor(p => p.DefaultDays).GreaterThan(0).NotNull()
                                       .WithMessage("{PropertyName} is required");
        }
    }
}
