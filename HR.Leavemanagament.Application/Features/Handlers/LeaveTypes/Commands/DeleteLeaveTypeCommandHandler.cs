using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Exceptions;
using HR.Leavemanagament.Application.Responses;
using HR.Leavemanagament.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveTypes.Commands
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IUnityOfWork _unityOfWork;
    
        public DeleteLeaveTypeCommandHandler(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<BaseCommandResponse> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var leaveType = await _leaveTypeRepository.Get(request.Id);

            if (leaveType is null) throw new NotFoundException(nameof(LeaveType), request.Id);

            await _unityOfWork.leaveTypeRepository.Delete(leaveType);
            await _unityOfWork.SaveChanges();

            response.Message = "Delete succesful";
            response.Success = true;

            return response;
        }
    }
}
