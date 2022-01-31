using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.DTOs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class GetLeaveRequestRequestHandler : IRequestHandler<GetLeaveRequestRequest, List<LeaveRequestListDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public GetLeaveRequestRequestHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<LeaveRequestListDto>>
                   (await _unityOfWork.leaveRequestResposity.GetLeaveRequestWithDetails());
        }
    }
}
