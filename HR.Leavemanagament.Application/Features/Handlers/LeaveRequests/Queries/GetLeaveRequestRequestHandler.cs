using AutoMapper;
using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class GetLeaveRequestRequestHandler : IRequestHandler<GetLeaveRequestRequest, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestResposity _leaveRequestResposity;
        private readonly IMapper _mapper;

        public GetLeaveRequestRequestHandler(ILeaveRequestResposity leaveRequestResposity, IMapper mapper)
        {
            _leaveRequestResposity = leaveRequestResposity;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<LeaveRequestListDto>>(await _leaveRequestResposity.GetLeaveRequestWithDetails());
        }
    }
}
