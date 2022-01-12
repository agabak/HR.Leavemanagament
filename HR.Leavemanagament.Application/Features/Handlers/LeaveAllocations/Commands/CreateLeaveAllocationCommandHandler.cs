using AutoMapper;
using HR.Leavemanagament.Application.DTOs.LeaveAllocations.Validators;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Responses;
using HR.Leavemanagament.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {

        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;


        public CreateLeaveAllocationCommandHandler
            (ILeaveAllocationRepository leaveAllocationRepository,
             ILeaveTypeRepository leaveTypeRepository,
             IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveAllocationValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.createAllocationDto);

            if(!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Fail to create Leave Allocation";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.createAllocationDto);

            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            response.Id = leaveAllocation.Id;
            response.Success = true;
            response.Message = "Leave Allocation Created Successful";
            return response;
        }
    }
}
