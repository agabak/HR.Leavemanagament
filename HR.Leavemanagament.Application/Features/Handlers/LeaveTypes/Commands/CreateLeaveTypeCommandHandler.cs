using AutoMapper;
using HR.Leavemanagament.Application.DTOs.LeaveTypes.Validators;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Responses;
using HR.Leavemanagament.Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {

        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;


        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateLeaveTypeValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Fail to create LeaveType";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var leaveType = await _leaveTypeRepository.Add(_mapper.Map<LeaveType>(request.LeaveTypeDto));

            response.Id = leaveType.Id;
            response.Success = true;
            response.Message = "LeaveType Created successful";


            return response;
        }
    }
}
