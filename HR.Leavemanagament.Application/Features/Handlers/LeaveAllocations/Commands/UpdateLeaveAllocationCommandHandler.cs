using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.DTOs.LeaveAllocations.Validators;
using HR.Leavemanagament.Application.Exceptions;
using HR.Leavemanagament.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveAllocations.Commands
{
    public  class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, BaseCommandResponse>
    {
     
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;

        public UpdateLeaveAllocationCommandHandler
            (IUnityOfWork unityOfWork,IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateLeaveAllocationValidator(_unityOfWork.leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);

            if (!validationResult.IsValid) throw new ValidationException(validationResult);
          

            var leaveAllocation = await _unityOfWork.leaveAllocationRepository.Get(request.UpdateLeaveAllocationDto.Id);
            if (leaveAllocation is null) throw new NotFoundException(nameof(leaveAllocation), request.UpdateLeaveAllocationDto.Id);

            _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation);

            await _unityOfWork.leaveAllocationRepository.Update(leaveAllocation);
            await _unityOfWork.SaveChanges();

            response.Success = true;
            response.Message = "LeaveAllocation update successful";
            response.Id = leaveAllocation.Id;
            return response;
        }
    }
}
