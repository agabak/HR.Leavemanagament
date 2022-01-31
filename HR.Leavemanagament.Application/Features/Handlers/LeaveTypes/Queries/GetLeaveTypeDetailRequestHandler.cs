using AutoMapper;
using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR.Leavemanagament.Application.Exceptions;

namespace HR.Leavemanagament.Application.Features
{
    public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public GetLeaveTypeDetailRequestHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;

        }
        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _unityOfWork.leaveTypeRepository.Get(request.Id);

            if (leaveType == null) throw new NotFoundException(nameof(LeaveRequestDto), request.Id);

            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}
