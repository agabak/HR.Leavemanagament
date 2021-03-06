using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Exceptions;
using HR.Leavemanagament.Application.DTOs.LeaveTypes.Validators;
using HR.Leavemanagament.Application.Responses;
using HR.Leavemanagament.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveTypes.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;


        public UpdateLeaveTypeCommandHandler(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _unityOfWork.leaveTypeRepository.Get(request.UpdateLeaveTypeDto.Id);

            // return if nothing is there...
            if (leaveType is null) throw new NotFoundException(nameof(LeaveType), request.UpdateLeaveTypeDto.Id);

            var response = new BaseCommandResponse();
            var validator = new UpdateLeaveTypeValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveTypeDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request.UpdateLeaveTypeDto, leaveType);

            await _unityOfWork.leaveTypeRepository.Update(leaveType);
            await _unityOfWork.SaveChanges();

            response.Id = leaveType.Id;
            response.Success = true;
            response.Message = "LeaveType Updated successful";

            return response;
        }
    }
}
