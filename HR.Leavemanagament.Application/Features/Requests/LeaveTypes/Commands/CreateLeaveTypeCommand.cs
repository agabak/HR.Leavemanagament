using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Responses;
using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class CreateLeaveTypeCommand: IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
