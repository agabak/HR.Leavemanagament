using AutoMapper;
using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class GetLeaveAllocationDetailRequestHandler : IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDto>
    {
       
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public GetLeaveAllocationDetailRequestHandler
            (IMapper mapper, IUnityOfWork unityOfWork)
        {
            _mapper = mapper;
            _unityOfWork = unityOfWork;
        }
        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<LeaveAllocationDto>(await _unityOfWork.leaveAllocationRepository.GetLeaveAllocationWithDetail(request.Id));
        }
    }
}
