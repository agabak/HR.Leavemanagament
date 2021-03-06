using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Responses;
using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class ChangeLeaveRequestApprovalCommand : IRequest<BaseCommandResponse>
    {
        public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApproval { get; set; }
    }
}
