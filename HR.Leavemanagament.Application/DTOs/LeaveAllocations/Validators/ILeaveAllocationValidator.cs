using FluentValidation;
using HR.Leavemanagament.Application.Contracts.Persistence;
using System;

namespace HR.Leavemanagament.Application.DTOs.LeaveAllocations.Validators
{
    public class ILeaveAllocationValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ILeaveAllocationValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.NumberOfDays).GreaterThan(0).WithMessage("{PropertyName} is required");
            RuleFor(p => p.Period)
                          .GreaterThan(0)
                          .GreaterThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} must valid year");

            RuleFor(p => p.LeaveTypeId).GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var isExit = await _leaveTypeRepository.Exist(id);
                    return isExit;

                }).WithMessage("{PropertyName} must exists");
        }
    }
}
