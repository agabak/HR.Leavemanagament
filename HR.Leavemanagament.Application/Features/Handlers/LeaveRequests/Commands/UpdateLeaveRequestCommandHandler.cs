using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Infrastructure;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Exceptions;
using HR.Leavemanagament.Application.DTOs.LeaveRequests.Validators;
using HR.Leavemanagament.Application.Models;
using HR.Leavemanagament.Application.Responses;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using HR.Leavemanagament.Domain;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveRequests.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestResposity _leaveRequestResposity;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateLeaveRequestCommandHandler(ILeaveRequestResposity leaveRequestResposity,
             ILeaveTypeRepository leaveTypeRepository,
             IMapper mapper, IEmailSender emailSender, IUnityOfWork unityOfWork)
        {
            _leaveRequestResposity = leaveRequestResposity;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _emailSender = emailSender;
            _unityOfWork = unityOfWork;
        }


        public async Task<BaseCommandResponse> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _unityOfWork
                                    .leaveRequestResposity
                                    .Get(request.UpdateLeaveRequestDto.Id);
            if (leaveRequest is null) 
                  throw new NotFoundException(nameof(LeaveType), request.UpdateLeaveRequestDto.Id);

            var response = new BaseCommandResponse();
            var validator = new UpdateLeaveRequestValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveRequestDto);

            if (!validationResult.IsValid) throw new ValidationException(validationResult);
       

            _mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);

            await  _unityOfWork.leaveRequestResposity .Update(leaveRequest);
            await _unityOfWork.SaveChanges();

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
