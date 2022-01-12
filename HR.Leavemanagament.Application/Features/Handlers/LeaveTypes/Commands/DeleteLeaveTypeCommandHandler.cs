using HR.Leavemanagament.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveTypes.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
    
        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);

            if (leaveType is null) throw new Exception();

            await _leaveTypeRepository.Delete(leaveType);

            return Unit.Value;
        }
    }
}
