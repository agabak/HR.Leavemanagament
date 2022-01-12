using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Responses;
using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class UpdateLeaveTypeCommand: IRequest<BaseCommandResponse>
    {
        public UpdateLeaveTypeDto UpdateLeaveTypeDto { get; set; }
    }
}
