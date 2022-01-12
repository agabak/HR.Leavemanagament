using HR.Leavemanagament.Application.DTOs;
using MediatR;

namespace HR.Leavemanagament.Application.Features
{
    public class GetLeaveRequestDetailRequest: IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
