using HR.Leavemanagament.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
       
        private readonly IUnityOfWork _unityOfWork;
    
        public DeleteLeaveAllocationCommandHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _unityOfWork.leaveAllocationRepository.Get(request.Id);

            if (leaveAllocation is null) throw new Exception();

            await _unityOfWork.leaveAllocationRepository.Delete(leaveAllocation);
            await _unityOfWork.SaveChanges();

            return Unit.Value;
        }
    }
}
