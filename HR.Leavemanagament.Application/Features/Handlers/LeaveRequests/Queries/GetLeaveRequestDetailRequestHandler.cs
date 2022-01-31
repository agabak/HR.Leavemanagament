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
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public GetLeaveRequestDetailRequestHandler(IUnityOfWork unityOfWork, IMapper  mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<LeaveRequestDto>
                   (await _unityOfWork.leaveRequestResposity.GetLeaveRequestWithDetail(request.Id));
        }
    }
}
