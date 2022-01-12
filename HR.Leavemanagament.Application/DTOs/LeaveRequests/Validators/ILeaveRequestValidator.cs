using FluentValidation;
using HR.Leavemanagament.Application.Contracts.Persistence;
using System;

namespace HR.Leavemanagament.Application.DTOs.LeaveRequests.Validators
{
    public class ILeaveRequestValidator :AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepositor;

        public ILeaveRequestValidator(ILeaveTypeRepository leaveTypeRepositor)
        {
            _leaveTypeRepositor = leaveTypeRepositor;

            RuleFor(p => p.StartDate).NotEmpty()
                                     .NotNull()
                                     .WithMessage("{PropertyName} is required");

            RuleFor(p => p.StartDate).GreaterThan(DateTime.Now)
                                     .WithMessage("{PropertyName} must be greater than tody");

            RuleFor(p => p.EndDate).NotEmpty().NotNull()
                                   .GreaterThan(p => p.StartDate)
                                   .WithMessage("{PropertyName} must be greater than Start Date");

            RuleFor(p => p.LeaveTypeId).GreaterThan(0)
                                       .MustAsync(async (id, token) =>
                                       {
                                            var isExist = await _leaveTypeRepositor.Exist(id);
                                            return isExist;
                                       }).WithMessage("{PropertyName} must a vaild id");
        }
    }
}
