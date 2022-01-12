using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Responses;
using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class CreateLeaveAllocationCommand: IRequest<BaseCommandResponse>
    {
        public CreateLeaveAllocationDto createAllocationDto { get; set; }
    }
}
