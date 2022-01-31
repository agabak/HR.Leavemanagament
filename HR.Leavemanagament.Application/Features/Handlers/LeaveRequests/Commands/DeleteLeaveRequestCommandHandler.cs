using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Exceptions;
using HR.Leavemanagament.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveRequests.Commands
{
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    {
        private readonly IUnityOfWork _unityOgWork;
        private readonly IMapper _mapper;

        public DeleteLeaveRequestCommandHandler(IMapper mapper, IUnityOfWork unityOfWork)
        {
            _unityOgWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _unityOgWork.leaveRequestResposity.Get(request.Id);

            if (leaveRequest is null) throw new NotFoundException(nameof(LeaveRequest), request.Id);

            await _unityOgWork.leaveRequestResposity.Delete(leaveRequest);
            await _unityOgWork.SaveChanges();

            return Unit.Value;
        }
    }
}
