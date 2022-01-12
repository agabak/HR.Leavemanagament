using AutoMapper;
using HR.Leavemanagament.Application.DTOs.LeaveRequests.Validators;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Responses;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HR.Leavemanagament.Application.Contracts.Infrastructure;
using HR.Leavemanagament.Application.Models;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveRequests.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestResposity _leaveRequestResposity;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public UpdateLeaveRequestCommandHandler(ILeaveRequestResposity leaveRequestResposity,
             ILeaveTypeRepository leaveTypeRepository,
             IMapper mapper, IEmailSender emailSender)
        {
            _leaveRequestResposity = leaveRequestResposity;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }


        public async Task<BaseCommandResponse> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateLeaveRequestValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDto);

            if(!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Fail to create leaveRequest";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var leaveRequest = await _leaveRequestResposity.Get(request.UpdateLeaveRequestDto.Id);

            if (leaveRequest is null) throw new Exception();

            _mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);

            await _leaveRequestResposity.Update(leaveRequest);

            response.Success = true;
            response.Message = "leaveRequest created successful";
            response.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "employee@org.com",
                Body = $"Your leave request for {request.UpdateLeaveRequestDto.StartDate:D} to { request.UpdateLeaveRequestDto.EndDate:D} has been updated successfully",
                Subject = "Leave Request Updated"
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
