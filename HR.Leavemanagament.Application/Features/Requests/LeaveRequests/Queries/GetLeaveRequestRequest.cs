using HR.Leavemanagament.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace HR.Leavemanagament.Application.Features
{
    public class GetLeaveRequestRequest: IRequest<List<LeaveRequestListDto>>
    {
    }
}
