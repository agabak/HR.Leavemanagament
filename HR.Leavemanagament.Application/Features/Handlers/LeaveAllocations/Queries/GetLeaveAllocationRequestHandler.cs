using AutoMapper;
using HR.Leavemanagament.Application.DTOs;
using HR.Leavemanagament.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class GetLeaveAllocationRequestHandler : IRequestHandler<GetLeaveAllocationRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<LeaveAllocationDto>>(await _leaveAllocationRepository.GetLeaveAllocationsWithDetails());
        }
    }
}
