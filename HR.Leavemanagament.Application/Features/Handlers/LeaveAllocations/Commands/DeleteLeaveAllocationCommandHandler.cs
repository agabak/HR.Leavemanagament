using HR.Leavemanagament.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);

            if (leaveAllocation is null) throw new Exception();

            await _leaveAllocationRepository.Delete(leaveAllocation);

            return Unit.Value;
        }
    }
}
