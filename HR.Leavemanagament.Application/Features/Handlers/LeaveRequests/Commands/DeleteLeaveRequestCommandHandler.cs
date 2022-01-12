using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.DTOs.Exceptions;
using HR.Leavemanagament.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveRequests.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestResposity _leaveRequestResposity;
        public DeleteLeaveRequestCommandHandler(ILeaveRequestResposity leaveRequestResposity)
        {
            _leaveRequestResposity = leaveRequestResposity;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestResposity.Get(request.Id);

            if (leaveRequest is null) throw new NotFoundException(nameof(LeaveRequest), request.Id);

            await _leaveRequestResposity.Delete(leaveRequest);

            return Unit.Value;
        }
    }
}
