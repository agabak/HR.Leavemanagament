using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Responses;
using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class UpdateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public UpdateLeaveRequestDto   UpdateLeaveRequestDto { get; set; }
    }
}
