using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.DTOs.Exceptions;
using HR.Leavemanagament.Application.DTOs.LeaveRequests.Validators;
using HR.Leavemanagament.Application.Responses;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveRequests.Commands
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestResposity _leaveRequestResposity;
        private readonly IMapper _mapper;

        public ChangeLeaveRequestApprovalCommandHandler(ILeaveRequestResposity leaveRequestResposity, IMapper mapper)
        {
            _leaveRequestResposity = leaveRequestResposity;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new ChangeLeaveRequestApprovalValidator();
            var validationResult = await validator.ValidateAsync(request.ChangeLeaveRequestApproval);

            if(!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Fail to approval leave request";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var leaveRequest = await _leaveRequestResposity.Get(request.ChangeLeaveRequestApproval.Id);

            if (leaveRequest is null) 
                 throw new NotFoundException(nameof(ChangeLeaveRequestApprovalDto), request.ChangeLeaveRequestApproval.Id);

            leaveRequest.Approved = request.ChangeLeaveRequestApproval.Approval;

            await _leaveRequestResposity.Update(leaveRequest);

            response.Success = true;
            response.Message = "Leave Request is approved";
            response.Id = leaveRequest.Id;
            return response;
        }
    }
}
