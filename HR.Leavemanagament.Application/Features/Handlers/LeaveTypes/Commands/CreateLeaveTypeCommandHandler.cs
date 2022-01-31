using AutoMapper;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.DTOs.LeaveTypes.Validators;
using HR.Leavemanagament.Application.Exceptions;
using HR.Leavemanagament.Application.Responses;
using HR.Leavemanagament.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;


        public CreateLeaveTypeCommandHandler(IUnityOfWork unityOfWork,IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateLeaveTypeValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var leaveType = await _unityOfWork.leaveTypeRepository.Add(_mapper.Map<LeaveType>(request.LeaveTypeDto));
                            await _unityOfWork.SaveChanges();

            response.Id = leaveType.Id;
            response.Success = true;
            response.Message = "LeaveType Created successful";

            return response;
        }
    }
}
