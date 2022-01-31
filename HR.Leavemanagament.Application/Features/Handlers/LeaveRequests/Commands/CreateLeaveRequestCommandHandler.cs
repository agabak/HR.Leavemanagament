using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Infrastructure;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Exceptions;
using HR.Leavemanagament.Application.DTOs.LeaveRequests.Validators;
using HR.Leavemanagament.Application.Models;
using HR.Leavemanagament.Application.Responses;
using HR.Leavemanagament.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using HR.Leavemanagament.Application.Constants;

namespace HR.Leavemanagament.Application.Features
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateLeaveRequestCommandHandler(IMapper mapper,IEmailSender emailSender,
                                                IUnityOfWork unityOfWork,IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _emailSender = emailSender;
            _unityOfWork = unityOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestValidator(_unityOfWork.leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(q => q.Type == CustomClaimTypes.uid).Value;

            var allocations = await _unityOfWork.leaveAllocationRepository
                                   .GetUserAllocation(userId, request.CreateLeaveRequestDto.LeaveTypeId);

            if (allocations is null)
            {
                validationResult.Errors
                                .Add(new FluentValidation.Results
                                .ValidationFailure(nameof(request.CreateLeaveRequestDto.LeaveTypeId), ""));
            }

            if (!validationResult.IsValid) throw new ValidationException(validationResult);


            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);

            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = userId;

            leaveRequest = await _unityOfWork.leaveRequestResposity.Add(leaveRequest);
                           await _unityOfWork.SaveChanges();

            response.Id = leaveRequest.Id;
            response.Success = true;
            response.Message = "LeaveRequest created successful";

            var email = new Email
            {
                To = "employee@org.com",
                Body = $"Your leave request for {request.CreateLeaveRequestDto.StartDate} to { request.CreateLeaveRequestDto.EndDate} has been submitted successfully",
                Subject = "Leave Request Submitted"
            };

            try
            {
                await _emailSender.SendEmail(email);
            }
            catch (Exception ex)
            {
                // handle errors
                
            }

            return response;
        }
    }
}
