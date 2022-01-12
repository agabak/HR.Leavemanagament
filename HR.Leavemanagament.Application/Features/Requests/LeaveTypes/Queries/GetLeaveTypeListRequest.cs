using HR.Leavemanagament.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {

    }
}
