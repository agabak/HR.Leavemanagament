using AutoMapper;
using HR.Leavemanagament.Application.DTOs.LeaveAllocations.Validators;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Responses;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveAllocations.Commands
{
    public  class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveAllocationCommandHandler
            (ILeaveAllocationRepository leaveAllocationRepository,
             ILeaveTypeRepository leaveTypeRepository,
              IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateLeaveAllocationValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);

            if (!validationResult.IsValid)
            {
                response.Id = request.UpdateLeaveAllocationDto.Id;
                response.Success = false;
                response.Message = "Fail to update LeaveAllocation";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var leaveAllocation = await _leaveAllocationRepository.Get(request.UpdateLeaveAllocationDto.Id);
            if (leaveAllocation is null) throw new Exception();

            _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation);

            await _leaveAllocationRepository.Update(leaveAllocation);

            response.Success = true;
            response.Message = "LeaveAllocation update successful";
            response.Id = leaveAllocation.Id;
            return response;
        }
    }
}
