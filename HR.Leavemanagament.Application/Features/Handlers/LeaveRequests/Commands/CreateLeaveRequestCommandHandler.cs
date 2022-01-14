using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Infrastructure;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.DTOs.Exceptions;
using HR.Leavemanagament.Application.DTOs.LeaveRequests.Validators;
using HR.Leavemanagament.Application.Models;
using HR.Leavemanagament.Application.Responses;
using HR.Leavemanagament.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestResposity _leaveRequestResposity;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestCommandHandler(ILeaveRequestResposity leaveRequestResposity,
                                                ILeaveTypeRepository leaveTypeRepository,
                                                IMapper mapper,
                                                IEmailSender emailSender)
        {
            _leaveRequestResposity = leaveRequestResposity;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }


            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);

            leaveRequest.DateRequested = DateTime.Now;

            leaveRequest = await _leaveRequestResposity.Add(leaveRequest);

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
