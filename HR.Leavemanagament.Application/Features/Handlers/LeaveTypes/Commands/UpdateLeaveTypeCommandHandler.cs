using AutoMapper;
using HR.Leavemanagament.Application.DTOs.LeaveTypes.Validators;
using HR.Leavemanagament.Application.Contracts.Persistence;
using HR.Leavemanagament.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.Leavemanagament.Application.Features.Handlers.LeaveTypes.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, BaseCommandResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;


        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateLeaveTypeValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveTypeDto);

            if(!validationResult.IsValid)
            {
                response.Id = request.UpdateLeaveTypeDto.Id;
                response.Success = false;
                response.Message = "Fail to update LeaveType";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            var leaveType = await _leaveTypeRepository.Get(request.UpdateLeaveTypeDto.Id);

            if (leaveType is null) throw new Exception();

            _mapper.Map(request.UpdateLeaveTypeDto, leaveType);

            await _leaveTypeRepository.Update(leaveType);

            response.Id = leaveType.Id;
            response.Success = true;
            response.Message = "LeaveType Updated successful";

            return response;
        }
    }
}
