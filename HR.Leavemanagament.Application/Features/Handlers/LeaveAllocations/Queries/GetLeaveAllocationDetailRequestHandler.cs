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
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationDetailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<LeaveAllocationDto>(await _leaveAllocationRepository.GetLeaveAllocationWithDetail(request.Id));
        }
    }
}
