using AutoMapper;
using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class GetLeaveRequestDetailRequestHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestResposity _leaveRequestResposity;
        private readonly IMapper _mapper;

        public GetLeaveRequestDetailRequestHandler(ILeaveRequestResposity leaveRequestResposity, IMapper mapper)
        {
            _leaveRequestResposity = leaveRequestResposity;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<LeaveRequestDto>(await _leaveRequestResposity.GetLeaveRequestWithDetail(request.Id));
        }
    }
}
