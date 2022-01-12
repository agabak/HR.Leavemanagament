using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Responses;
using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
    }
}
