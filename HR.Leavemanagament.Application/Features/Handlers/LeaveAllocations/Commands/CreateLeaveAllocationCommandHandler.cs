using AutoMapper;
using HR.Leavemanagament.Application.DTOs.LeaveAllocations.Validators;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Responses;
using HR.Leavemanagament.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HR.Leavemanagament.Application.Contracts.Identity;
using System;
using System.Collections.Generic;

namespace HR.Leavemanagament.Application.Features
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private IUnityOfWork _unityOfWork;
        private IUserService _userService;
       
        public CreateLeaveAllocationCommandHandler
            (ILeaveTypeRepository leaveTypeRepository,
             IUnityOfWork unityOfWork,
             IUserService userService)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _unityOfWork = unityOfWork;
            _userService = userService;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.createAllocationDto);

            if(!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Fail to create Leave Allocation";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var leaveType = await _unityOfWork.leaveTypeRepository.Get(request.createAllocationDto.LeaveTypeId);
            var employees = await _userService.GetEmployees();
            var period = DateTime.Now.Year;
            var allocations = new List<LeaveAllocation>();

            foreach(var employee in employees)
            {
                if (await _unityOfWork.leaveAllocationRepository.AllocationExists(employee.Id, leaveType.Id, period)) continue;

                allocations.Add(new LeaveAllocation
                    {
                        EmployeeId = employee.Id,
                        LeaveTypeId = leaveType.Id,
                        NumberOfDays = leaveType.DefaultDays,
                        Period = period
                    });
            }

            await _unityOfWork.leaveAllocationRepository.AddAllocations(allocations);
            await _unityOfWork.SaveChanges();
            response.Success = true;
            response.Message = "Leave Allocation Created Successful";
            return response;
        }
    }
}
