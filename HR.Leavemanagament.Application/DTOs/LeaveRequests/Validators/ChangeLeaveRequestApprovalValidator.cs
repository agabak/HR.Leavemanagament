using FluentValidation;

namespace HR.Leavemanagament.Application.DTOs.LeaveRequests.Validators
{
    public class ChangeLeaveRequestApprovalValidator : AbstractValidator<ChangeLeaveRequestApprovalDto>
    {
        public ChangeLeaveRequestApprovalValidator()
        {
            RuleFor(p => p.Approval).NotEmpty()
                                    .NotNull().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Id).GreaterThan(0)
                              .WithMessage("{PropertyName} is required");
        }
    }
}
