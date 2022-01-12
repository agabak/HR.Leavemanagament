using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Responses;
using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class UpdateLeaveAllocationCommand : IRequest<BaseCommandResponse>
    {
        public UpdateLeaveAllocationDto UpdateLeaveAllocationDto { get; set; }
    }
}
